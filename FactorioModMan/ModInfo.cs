using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FactorioModMan.Properties;
using Newtonsoft.Json;

namespace FactorioModMan
{
    public struct CategorieInfo
    {
        public int Id;
        public string Title;
        public string Name;
    }

    public class ModInfo
    {
        //some helpers
        internal Bitmap Image = new Bitmap(Resources.missing_thumbnail);
        public override string ToString()
        {
            return $"{Name}::{Title}";
        }

        public uint Id { get; set; }
        public string Url { get; set; }
        public IList<string> Categories { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Homepage { get; set; }
        public IList<ReleaseInfo> Releases { get; set; }


        public static bool TryParse(string url, out ModInfo urlObj)
        {
            urlObj = new ModInfo();
            try
            {
                if (!url.StartsWith("factoriomods://")) return false;
                if (url.Length <= 15) return false;
                url = url.Remove(0, 15);
                byte[] rawBase64 = Convert.FromBase64String(url);
                string json = Encoding.UTF8.GetString(rawBase64);

                urlObj = JsonConvert.DeserializeObject<ModInfo>(json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal ListViewItem ToListViewItem(Version installedVersion, LocalModManager.ModState state)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = lvi.Name = Name;
            string stateStr;

            switch (state)
            {
                case LocalModManager.ModState.NotInstalled:
                    stateStr = "not installed";
                    break;
                case LocalModManager.ModState.InstalledDisabled:
                    stateStr = "disabled";
                    break;
                case LocalModManager.ModState.InstalledEnabled:
                    stateStr = "enabled";
                    break;
                default:
                    stateStr = "";
                    break;
            }

            lvi.SubItems.Add(installedVersion.ToString(3));
            lvi.SubItems.Add(stateStr);
            lvi.SubItems.Add(Title);
            lvi.SubItems.Add(Description);
            lvi.SubItems.Add(Author);
            return lvi;
        }

        internal string GetImageCacheFile(string cachePath)
        {
            string cacheFile = Name;
            foreach (char c in Path.GetInvalidFileNameChars()) cacheFile = cacheFile.Replace(c, '_');
            cacheFile = cacheFile.Replace(' ', '_');
            cacheFile = cacheFile.ToLower();
            cacheFile = Path.Combine(cachePath, cacheFile);
            return cacheFile;
        }

        internal void PreloadImage(string cachePath)
        {
            try
            {
                if (File.Exists(GetImageCacheFile(cachePath)))
                    Image = new Bitmap(GetImageCacheFile(cachePath));
            }
            catch (Exception)
            {
            }
        }

        public struct ReleaseInfo
        {
            public struct ReleaseFileInfo
            {
                public uint Id { get; set; }
                public string Name { get; set; }
                public string Mirror { get; set; }
                public Uri Url { get; set; }
            }

            public uint Id { get; set; }
            public string Version { get; set; }

            /// <summary>
            ///     Gets the best matching version. Can be NULL if any problems (e.g. no version in mod info, not parseable, etc.)
            /// </summary>
            /// <returns>Version or NULL</returns>
            public Version GetComparableGameVersion()
            {
                Version cVersion = null;
                if (Game_Versions != null && Game_Versions.Count() > 0)
                {
                    //mod has some versions... we just take the highest for reference
                    List<string> tmpVersions = (List<string>)Game_Versions; //convert from IList to List
                    tmpVersions.Sort(); //sort -> lowest top, highest bottom
                    string highestStringVersion = tmpVersions.Last();

                    do
                    {
                        //the ".x" is not very nice... as the X stands for any we can just cut it off. so the default of 0 will be should be the same as "any" when comparing.
                        if (!System.Version.TryParse(highestStringVersion, out cVersion))
                        {
                            highestStringVersion = highestStringVersion.Remove(highestStringVersion.Length - 1, 1);
                        }
                    } while (cVersion == null && highestStringVersion != "");
                }

                //two cases possible here: any version or NULL - both should be regarded

                return cVersion;
            }

            public DateTime? Released_At { get; set; }
            public IList<string> Game_Versions { get; set; }
            public IList<ReleaseFileInfo> Files { get; set; }

            public override string ToString()
            {
                return Version;
            }
        }
    }
}