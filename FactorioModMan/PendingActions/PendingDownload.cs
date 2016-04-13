using System;
using System.IO;
using System.Net;

namespace FactorioModMan.PendingActions
{
    internal class PendingDownload : PendingChangeBase
    {
        private ModInfo mod;
        private ModInfo.ReleaseInfo releaseInfo;
        private string targetFilename;

        public PendingDownload(ModInfo mod, ModInfo.ReleaseInfo releaseInfo, string targetFilename) : base(PendingAction.Download)
        {
            this.mod = mod;
            this.releaseInfo = releaseInfo;
            this.targetFilename = targetFilename;
        }

        public override PendingActionResult Run(OnlineModManager _onlineManager, LocalModManager _localManager)
        {
            //check if file does exist already, if so, no need to do anything
            if (File.Exists(targetFilename)) return PendingActionResult.Skipped;
            bool success = false;
            using (WebClient wc = new WebClient())
            {
                foreach (ModInfo.ReleaseInfo.ReleaseFileInfo releaseFileInfo in releaseInfo.Files)
                {
                    //try url first
                    if (releaseFileInfo.Url != null)
                    {
                        try
                        {
                            wc.DownloadFile(releaseFileInfo.Url, targetFilename);
                            success = true;
                            break;
                        }
                        catch
                        {
                            // ignored because it's possible that the server not reachable
                        }
                    }
                    //try mirrors
                    if (!string.IsNullOrEmpty(releaseFileInfo.Mirror))
                    {
                        try
                        {
                            wc.DownloadFile(releaseFileInfo.Mirror, targetFilename);
                            success = true;
                            break;
                        }
                        catch
                        {
                            // ignored because it's possible that the server not reachable
                        }
                    }
                }
                //wc.DownloadFile(, targetFilename);
            }
            if (success) return PendingActionResult.Completed;
            else return PendingActionResult.Failed;
        }

        public override string ToString() => $"Download: {mod.Name} ({releaseInfo.Version})";

    }
}