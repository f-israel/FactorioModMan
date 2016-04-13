using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DamienG.Security.Cryptography;
using FactorioModMan.Properties;
using Ionic.Zip;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FactorioModMan
{
    internal class LocalModManager
    {
        public enum ModState : byte
        {
            NotInstalled = 0,
            InstalledEnabled = 1,
            InstalledDisabled = 2
        }

        public enum ModSyncState : byte
        {
            Installed = 0,
            NotInstalled = 1,
            LocalOutdated = 2,
            ServerOutdated = 3
        }

        private readonly List<ModInfo> _installedMods = new List<ModInfo>();
        private readonly Dictionary<string, bool> _installedModsEnabled = new Dictionary<string, bool>();
        private readonly Dictionary<string, Version> _installedModsVersions = new Dictionary<string, Version>();
        private readonly string _backupPath;

        private readonly string _modPath;

        public LocalModManager(string preCheckedModPath, string preCheckBackupPath)
        {
            if (!Directory.Exists(Settings.Default.ModPath)) throw new Exception("Path does not exist");

            _modPath = Path.GetFullPath(preCheckedModPath);
            _backupPath = Path.GetFullPath(preCheckBackupPath);
        }

        public List<ModInfo> ReadFolder(bool forceRescan = false)
        {
            if (_installedMods.Count == 0 || forceRescan)
            {
                _installedMods.Clear();
                _installedModsEnabled.Clear();
                _installedModsVersions.Clear();
                

                if (File.Exists(Path.Combine(_modPath, "mod-list.json")))
                {
                    string modlist = File.ReadAllText(Path.Combine(_modPath, "mod-list.json"));
                    JObject obj = (JObject)JsonConvert.DeserializeObject(modlist);
                    if (obj["mods"] != null)
                    {
                        foreach (JToken i in obj["mods"])
                        {
                            if (i["name"] != null && i["enabled"] != null)
                            {
                                if (!_installedModsEnabled.ContainsKey(i["name"].Value<string>()))
                                    _installedModsEnabled.Add(i["name"].Value<string>(), i["enabled"].Value<bool>());
                            }
                        }
                    }
                }
                List<string> possibleMods = new List<string>(Directory.EnumerateDirectories(_modPath));
                foreach (string possibleModFolder in possibleMods)
                {
                    string infoJson = Path.Combine(possibleModFolder, "info.json");
                    if (File.Exists(infoJson))
                    {
                        try
                        {
                            string info = File.ReadAllText(infoJson);
                            ModInfo mod = JsonConvert.DeserializeObject<ModInfo>(info);
                            _installedModsVersions.Add(mod.Name, new Version(JObject.Parse(info)["version"].ToString()));
                            _installedMods.Add(mod);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else continue;
                }
            }
            return new List<ModInfo>(_installedMods); //return copy
        }

        internal string GetDownloadPath(ModInfo mod, int releaseInfoIndex)
        {
            if (releaseInfoIndex == -1) releaseInfoIndex = 0; //-1 is latest version, so just change to 0 is no problem
            //try to build a mod-version unique filename
            string basename = $"{mod.Releases[releaseInfoIndex].Id}_{mod.Name}_{mod.Releases[releaseInfoIndex].Version}.zip";
            foreach (char invalidChar in Path.GetInvalidFileNameChars()) { basename = basename.Replace(invalidChar, '-'); } //remove invalid chars

            return Path.Combine(Settings.Default.DownloadTempPath, basename);
        }

        internal Version GetInstalledModVersion(ModInfo mod)
        {
            if (_installedModsVersions.ContainsKey(mod.Name)) return _installedModsVersions[mod.Name];
            return null;
        }

        internal ModState GetState(ModInfo mod)
        {
            //if mod not in state table, it doesn't exist locally
            if (!_installedModsEnabled.ContainsKey(mod.Name)) return ModState.NotInstalled;

            return _installedModsEnabled[mod.Name] ? ModState.InstalledEnabled : ModState.InstalledDisabled;
        }


        internal async Task Backup(Action<SaveProgressEventArgs> progressHandler = null)
        {
            string filename = DateTime.Now.ToString("yyyyMMdd_HHmm");

            string targetBackupFileName = Path.Combine(_backupPath, filename);
            //can't just check for exist as the checksum can vary
            //simples way: get all filenames and check with .startsWith
            int counter = 0;
            bool uniqueNameFound = !Directory.EnumerateFiles(_backupPath).Any(existingFilename => existingFilename.StartsWith(targetBackupFileName));
            while (!uniqueNameFound)
            {
                counter++;
                string tmpName = Path.Combine(_backupPath, filename + $"_{counter}");
                uniqueNameFound = !Directory.EnumerateFiles(_backupPath).Any(existingFilename => existingFilename.StartsWith(tmpName));
                if (uniqueNameFound) targetBackupFileName = tmpName;
            }

            await Task.Factory.StartNew(() =>
            {
                using (ZipFile zip = new ZipFile(targetBackupFileName))
                {
                    zip.AddDirectory(_modPath, "");
                    if (progressHandler != null)
                        zip.SaveProgress += (object sender, SaveProgressEventArgs e) =>
                        {
                            if (e.EventType != ZipProgressEventType.Saving_Completed) progressHandler(e);
                            else
                            {
                                //delay saving_completed to trigger after checksum
                                //now add a crc checksum to filename
                                string hash = string.Empty;
                                using (Crc32 crc32 = new Crc32()) { using (FileStream fs = File.Open(targetBackupFileName, FileMode.Open)) { hash = crc32.ComputeHash(fs).Aggregate(hash, (current, b) => current + b.ToString("x2").ToLower()); } }

                                File.Move(targetBackupFileName, targetBackupFileName + $"_[{hash.ToUpper()}].zip");
                                //everything done - pass delayed event
                                progressHandler(e);
                            }
                        };
                    zip.Save(targetBackupFileName);
                }
            });
        }

        internal ModSyncState CompareToLocal(ServerInfo.ServerModInfo modinfo)
        {
            if (!_installedModsVersions.ContainsKey(modinfo.Name)) return ModSyncState.NotInstalled;
            //sometimes we get a Version object with a revision (4th position) given. that is NOT compareable to a 3 part version. just make them comform
            Version installedVersionFixed = new Version(_installedModsVersions[modinfo.Name].Major, _installedModsVersions[modinfo.Name].Minor, _installedModsVersions[modinfo.Name].Build);
            Version wantedVersionFixed = new Version(modinfo.Version.Major, modinfo.Version.Minor, modinfo.Version.Build);

            //for performance we make an explicit "if" for matching instead of an "else"
            if (wantedVersionFixed == installedVersionFixed) return ModSyncState.Installed;

            if (wantedVersionFixed > installedVersionFixed) return ModSyncState.LocalOutdated;
            return ModSyncState.ServerOutdated;
        }

        internal async Task Restore(string filename, Action<SaveProgressEventArgs> backupHandler, Action<RestoreProgressEventArgs> progressHandler)
        {
            //before anything else: if checksum given, compare them
            if (Regex.IsMatch(filename, @"\[([0-9A-F]{8})\]\.zip", RegexOptions.Compiled | RegexOptions.IgnoreCase))
            {
                Match m = Regex.Match(filename, @"\[([0-9A-F]{8})\]\.zip", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                string givenHash = m.Result("$1");
                string hash = string.Empty;
                using (Crc32 crc32 = new Crc32()) { using (FileStream fs = File.Open(filename, FileMode.Open)) { hash = crc32.ComputeHash(fs).Aggregate(hash, (current, b) => current + b.ToString("x2").ToLower()); } }
                if (!string.Equals(givenHash, hash, StringComparison.CurrentCultureIgnoreCase))
                {
                    MessageBox.Show("Checksum missmatch. We can't restore this file.");
                    return;
                }
                if (!ZipFile.CheckZip(filename))
                {
                    MessageBox.Show("The given file is not a valid zip file. We can't restore this file.");
                    return;
                }
            }
            if (MessageBox.Show("Restoring a backup will remove all currently installed mods. A backup will be created automatically.\r\nDo you want to continue?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await Backup(backupHandler);
                progressHandler(new RestoreProgressEventArgs("Initializing restore", 0, 100, false));

                await Task.Factory.StartNew(() =>
                {
                    progressHandler(new RestoreProgressEventArgs("Cleaning mod folder", 0, 100, false));
                    //Directory.Delete(Settings.Default.ModPath, true);
                    //we don't want to delete the mods folder, so loop over each subfolder
                    Program.CleanFolderContents(Settings.Default.ModPath);
                    progressHandler(new RestoreProgressEventArgs("Restoring folder", 0, 100, false));


                    using (ZipFile zip = ZipFile.Read(filename))
                    {
                        progressHandler(new RestoreProgressEventArgs("Restoring", 0, zip.Count, false));
                        zip.ExtractProgress += (object sender, ExtractProgressEventArgs e) =>
                        {
                            if (e.EventType == ZipProgressEventType.Extracting_AfterExtractEntry)
                            {
                                if (e.EntriesExtracted % 10 == 0 || e.EntriesExtracted == e.EntriesTotal)
                                {
                                    progressHandler(new RestoreProgressEventArgs("Restoring: " + e.CurrentEntry.FileName.Split('/').First(), e.EntriesExtracted, e.EntriesTotal, false));
                                }
                            }
                            else if (e.EventType == ZipProgressEventType.Extracting_AfterExtractAll)
                            {

                                progressHandler(new RestoreProgressEventArgs("Finished", e.EntriesExtracted, e.EntriesTotal, true));
                            }
                        };
                        zip.ExtractAll(Settings.Default.ModPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                });
                MessageBox.Show("Restore completed");
            }
        }

        internal void Uninstall(ModInfo mo)
        {
            throw new NotImplementedException();
        }

        internal void Install(ModInfo mod)
        {
            throw new NotImplementedException();
        }

        public struct RestoreProgressEventArgs
        {
            public RestoreProgressEventArgs(string _txt, int _val, int _max, bool _hideProgress)
            {
                txt = _txt;
                val = _val;
                max = _max;
                hideProgress = _hideProgress;
            }

            public bool hideProgress;
            public int val;
            public int max;
            public string txt;
        }
    }
}