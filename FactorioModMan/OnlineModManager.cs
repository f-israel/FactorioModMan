using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactorioModMan.Properties;
using Newtonsoft.Json;

namespace FactorioModMan
{
    internal class OnlineModManager
    {
        internal class WebClientCached : IDisposable
        {
            private readonly bool _debugCacheHtml = true;
            private readonly string _debugCacheHtmlPath = Settings.Default.CachePath;
            private WebClient _webClient;

            public WebClientCached()
            {
                _webClient = new WebClient();
            }

            public void Dispose()
            {
                ((IDisposable)_webClient).Dispose();
            }

            internal string GetString(string url) { return GetString(new Uri(url)); }
            internal string GetString(Uri url)
            {
                if (_debugCacheHtml)
                {
                    string tmpFile = Path.Combine(_debugCacheHtmlPath, "html_" + Program.GetMd5Hash(url.ToString()));
                    if (File.Exists(tmpFile)) { return File.ReadAllText(tmpFile); }
                    string response = _webClient.DownloadString(url);
                    File.WriteAllText(tmpFile, response);
                    return response;
                }
                return _webClient.DownloadString(url);
            }

            internal void DownloadFile(string url, string localFile)
            {
                DownloadFile(new Uri((url)), localFile);
            }

            internal void DownloadFile(Uri url, string localFile)
            {
                if (_debugCacheHtml)
                {
                    string tmpFile = Path.Combine(_debugCacheHtmlPath, "raw_" + Program.GetMd5Hash(url.ToString()));
                    if (!File.Exists(tmpFile)) { _webClient.DownloadFile(url, tmpFile); }
                    File.Copy(tmpFile, localFile, true);
                    return;
                }
                _webClient.DownloadFile(url, localFile);
            }
        }
        private List<ModInfo> _allMods = new List<ModInfo>();

        private readonly string cachePath;
        private string downloadPath;

        public OnlineModManager()
        {
            cachePath = Settings.Default.CachePath;
            downloadPath = Settings.Default.DownloadTempPath;
        }

        internal event FetchingOnlineProgress OnFetchingOnlineProgress;
        public event FetchingOnlineCompleted OnFetchingOnlineCompleted;
        public event SearchResult OnSearchResult;


        public async Task StartOnline()
        {
            List<CategorieInfo> categories = _getCategories();
            if (categories == null || categories.Count == 0)
            {
                //fail
            }
            else
            {
                await Task.Delay(20); //give handler some time to work
                _allMods = _fetchAllMods();
                if (_allMods == null || _allMods.Count == 0)
                {
                    //fail
                }
                else
                {
                    await Task.Delay(20); //give handler some time to work
                    _fetchThumbnails(_allMods);
                    await Task.Delay(20); //give handler some time to work
                    _preloadThumbnails(_allMods);
                    await Task.Delay(20); //give handler some time to work

                    OnFetchingOnlineCompleted?.Invoke(_allMods, categories);
                }
            }
        }


        private List<CategorieInfo> _getCategories()
        {
            try
            {
                using (WebClientCached wc = new WebClientCached())
                {
                    string categories = wc.GetString("http://api.factoriomods.com/categories/");
                    List<CategorieInfo> res = JsonConvert.DeserializeObject<List<CategorieInfo>>(categories);
                    OnFetchingOnlineProgress?.Invoke(1, 100, $"Found: {res.Count}");
                    return res;
                    //CategorieInfo
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private List<ModInfo> _fetchAllMods()
        {
            try
            {
                using (WebClientCached wc = new WebClientCached())
                {
                    //fetching mods
                    List<ModInfo> allMods = new List<ModInfo>();

                    for (int i = 1; i < int.MaxValue; i++)
                    {
                        OnFetchingOnlineProgress?.Invoke(2, 0, $"Fetching page {i}");
                        string modsStr = wc.GetString($"http://api.factoriomods.com/mods?page={i}");
                        List<ModInfo> modsPage = JsonConvert.DeserializeObject<List<ModInfo>>(modsStr);

                        if (modsPage == null || modsPage.Count == 0)
                        {
                            OnFetchingOnlineProgress?.Invoke(2, 100, $"Fetched {i} pages", i > 100 ? i : int.MinValue);
                            //allMods.AddRange(modsPage); ? run or not run... that's the question - btw: do null checking
                            break;
                        }
                        allMods.AddRange(modsPage);
                    }
                    return allMods;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal ModInfo.ReleaseInfo? FindReleaseInfoByNameAndVersion(string name, Version version)
        {
            ModInfo mod = FindModByName(name);
            if (mod == null) return null;
            for (int i = 0; i < mod.Releases.Count; i++)
            {
                //seems like I made anywhere a little type misstake... Version != String... 
                if (version.ToString(3) == mod.Releases[i].Version) //this should work as well
                {
                    //this version is match. that's perfect
                    return mod.Releases[i];
                }
            }
            return null;
        }

        public bool SyncDone => _allMods.Count > 0;

        internal ModInfo FindModByName(string name)
        {
            //just a simple wrapper
            return _allMods.Find(_mod => _mod.Name == name);
        }

        private void _fetchThumbnails(List<ModInfo> allMods)
        {
            //fetching mods thumbnails
            int modCounter = 0;

            if (!Properties.Settings.Default.OnlineModsSkipThumbnails)
            {
                OnFetchingOnlineProgress?.Invoke(3, modCounter, $"Worked on {modCounter} mods", allMods.Count);
                foreach (ModInfo mod in allMods) //TODO: try again as multithreaded... was Parallel but that had a lot of race conditions
                {
                    modCounter++;
                    Console.WriteLine($"Getting image of {mod.Name}");
                    string cacheFile = mod.GetImageCacheFile(Settings.Default.CachePath);
                    //in cache?
                    if (File.Exists(cacheFile)) continue;
                    if (string.IsNullOrWhiteSpace(mod.Url)) continue;
                    // ... if not
                    using (WebClientCached thumbnailClient = new WebClientCached())
                    {
                        string pageContent = thumbnailClient.GetString(mod.Url);

                        //<div class='mod-image'><a href="http://i.imgur.com/1LrWdOj.jpg"><img src="http://i.imgur.com/1LrWdOjl.jpg" /></a></div>
                        Match match = Regex.Match(pageContent, "<div class=\'mod-image\'>.+?<img src=\"(?<ImgUri>.+?)\" />.+?</div>", RegexOptions.Compiled);
                        if (match.Success)
                        {
                            try
                            {
                                Debug.WriteLine($"Downloading: {mod.Name}");
                                thumbnailClient.DownloadFile(match.Result("$1"), cacheFile);
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                    }
                    OnFetchingOnlineProgress?.Invoke(3, modCounter, $"Worked on {modCounter} mods");
                }
            }
            OnFetchingOnlineProgress?.Invoke(3, modCounter, $"Worked on {allMods.Count} mods", allMods.Count);
        }

        private void _preloadThumbnails(List<ModInfo> allMods)
        {
            //image preloader
            for (int i = 0; i < allMods.Count; i++)
            {
                allMods[i].PreloadImage(Settings.Default.CachePath);
                if (i % 5 == 0) OnFetchingOnlineProgress?.Invoke(4, 0, $"{i} Images loaded", allMods.Count);
            }
        }

        internal void Download(ModInfo mod, string targetfile = null)
        {
            if (mod.Releases == null)
            {
                //only got half of information? try to complete with online mods
                //TODO: complete mod
            }
            List<ModInfo.ReleaseInfo> releases = new List<ModInfo.ReleaseInfo>(mod.Releases);
            if (releases.Count > 0)
            {
                ModInfo.ReleaseInfo ri = releases[0];
                ModInfo.ReleaseInfo.ReleaseFileInfo rfi = new List<ModInfo.ReleaseInfo.ReleaseFileInfo>(ri.Files)[0];

                Task.Factory.StartNew(() =>
                {
                    Uri dl;
                    if (rfi.Mirror != null)
                        dl = new Uri(rfi.Mirror.ToString());
                    else
                        dl = rfi.Url;

                    using (WebClientCached wc = new WebClientCached())
                    {
                        Console.WriteLine("Downloading: " + Path.GetFileName(dl.LocalPath));
                        wc.DownloadFile(dl, Path.Combine(Settings.Default.CachePath, Path.GetFileName(dl.LocalPath)));
                        Console.WriteLine("Downloaded: " + Path.GetFileName(dl.LocalPath));
                    }
                });
            }
        }

        internal ModInfo CompleteModInfo(ModInfo mod)
        {
            int listIdx = _allMods.IndexOf(mod);
            if (listIdx > -1) return _allMods[listIdx];
            else return mod;
        }
        internal void Search(string filterTxt, Version gameversion)
        {
            //this is not the efficentest way for filtering... this part is for readability optimized
            Func<ModInfo.ReleaseInfo, bool> versionCheck = (ModInfo.ReleaseInfo releaseInfo) => true;
            if (gameversion != null)
                versionCheck = (ModInfo.ReleaseInfo releaseInfo) =>
                {
                    Version modVersion = releaseInfo.GetComparableGameVersion();
                    if (modVersion != null) { return modVersion.Major == gameversion.Major && modVersion.Minor == gameversion.Minor; }
                    //here's a problem: the mod info doesn't contain any version... we assume it's not up-to-date and so not compatible
                    //TODO: check if negating makes sense
                    return false;
                };

            List<ModInfo> searchResult = new List<ModInfo>();
            foreach (ModInfo mod in _allMods)
            {
                if (!mod.Name.ToLower().Contains(filterTxt.ToLower())) continue;
                if (mod.Releases.Any(versionCheck)) { searchResult.Add(mod); }
            }

            OnSearchResult?.Invoke(searchResult);
        }

        internal delegate void FetchingOnlineProgress(int step, int progress, string additional = null, int maxProgress = int.MinValue);

        internal delegate void FetchingOnlineCompleted(List<ModInfo> allMods, List<CategorieInfo> allCategories);

        internal delegate void SearchResult(List<ModInfo> result);
    }
}