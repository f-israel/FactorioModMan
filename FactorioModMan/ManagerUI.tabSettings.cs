using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FactorioModMan.Properties;

namespace FactorioModMan
{
    public partial class ManagerUi : Form
    {
        public static bool CacheHtml = true;
        public static string[] ExperimentalTabs = { "tabOnlineMods", "tabServerSync" };


        public static List<string> AutodetectExecuteablePathTemplates = new List<string>
        {
            /* there are two special vars. if multiple values a loop will occure automatically
                %PF% - both ProgramFiles (x86 and x64)
                %ARCH% - resolves to x86 and x64
                %APPDATA% - resolves to users %APPDATA%
            */
            @"%PF%\Steam\steamapps\common\Factorio\bin\%ARCH%\Factorio.exe"
        };

        public static List<string> AutodetectModsPathTemplates = new List<string>
        {
            /* there are two special vars. if multiple values a loop will occure automatically
                %PF% - both ProgramFiles (x86 and x64)
                %ARCH% - resolves to x86 and x64
                %APPDATA% - resolves to users %APPDATA%
            */
            @"%APPDATA%\Factorio\mods\"
        };

        private bool _blockTabs;

        private void CTOR_TabSettings()
        {
            //set values to setting fields
            txtSettingsPathExecuteable.Text = Settings.Default.ExecuteablePath;
            txtPathCache.Text = Settings.Default.CachePath;
            txtSettingsModPath.Text = txtPathTemp.Text = Settings.Default.ModPath;
            txtPathTemp.Text = txtPathTemp.Text = Settings.Default.DownloadTempPath;
            txtPathBackup.Text = Settings.Default.BackupPath;
            cbEnableExperimental.Checked = Settings.Default.ExperimentalFeatures;
            cbEnableExperimental.Tag = null;

            cbSkipThumbnails.Checked = Settings.Default.OnlineModsSkipThumbnails;
        }

        private void btnSettingsMods_Click(object sender, EventArgs e)
        {
            if (openfolderSettingsModPath.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ModPath = openfolderSettingsModPath.SelectedPath;
            }
        }

        private void BtnSettingsExecuteable(object sender, EventArgs e)
        {
            if (openfileSettingsExecuteable.ShowDialog() == DialogResult.OK)
            {
                txtSettingsPathExecuteable.Text = Settings.Default.ExecuteablePath = openfileSettingsExecuteable.FileName;
            }
        }

        private void btnSettingsSave_Click(object sender, EventArgs e)
        {
            //basic checks
            if (string.IsNullOrWhiteSpace(txtPathCache.Text))
            {
                MessageBox.Show("The cache folder setting is missing. We set the default one automatically.");
                txtPathCache.Text = Path.Combine(@".\cache");
                Directory.CreateDirectory(txtPathCache.Text);
            }

            if (string.IsNullOrWhiteSpace(txtPathTemp.Text))
            {
                MessageBox.Show("The temp folder setting is missing. We set the default one automatically.");
                txtPathTemp.Text = Path.Combine(@".\temp");
                Directory.CreateDirectory(txtPathTemp.Text);
            }

            if (string.IsNullOrWhiteSpace(txtPathBackup.Text))
            {
                MessageBox.Show("The backup folder setting is missing. We set the default one automatically.");
                txtPathBackup.Text = Path.Combine(@".\backups");
                Directory.CreateDirectory(txtPathBackup.Text);
            }

            if (string.IsNullOrWhiteSpace(txtSettingsPathExecuteable.Text))
            {
                MessageBox.Show("There is missing a setting: executeable path");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSettingsModPath.Text))
            {
                MessageBox.Show("There is missing a setting: mods folder path");
                return;
            }


            //existence checks
            if (!_isValidPath(txtPathCache.Text))
            {
                MessageBox.Show("The cache path is not valid. Please chose another one.");
                return;
            }

            if (!_isValidPath(txtPathTemp.Text))
            {
                MessageBox.Show("The temp path is not valid. Please chose another one.");
                return;
            }
            if (!_isValidPath(txtPathBackup.Text))
            {
                MessageBox.Show("The backup path is not valid. Please chose another one.");
                return;
            }


            if (!Directory.Exists(txtPathCache.Text))
            {
                try
                {
                    Directory.CreateDirectory(txtPathCache.Text);
                }
                catch
                {
                    MessageBox.Show(
                        "The cache path does not exist nor could be created. Please create or chose another folder.");
                    return;
                }
            }

            if (!Directory.Exists(txtPathTemp.Text))
            {
                try
                {
                    Directory.CreateDirectory(txtPathTemp.Text);
                }
                catch
                {
                    MessageBox.Show(
                        "The temp path does not exist nor could be created. Please create or chose another folder.");
                    return;
                }
            }


            if (!Directory.Exists(txtPathBackup.Text))
            {
                try
                {
                    Directory.CreateDirectory(txtPathTemp.Text);
                }
                catch
                {
                    MessageBox.Show(
                        "The backup path does not exist nor could be created. Please create or chose another folder.");
                    return;
                }
            }


            //extended checks
            if (!_isWriteable(txtPathCache.Text, "FactorioModManWriteTest"))
            {
                MessageBox.Show("The cache path does not seem to be writeable. This is necessary. Please correct.");
                return;
            }

            if (!_isWriteable(txtPathTemp.Text, "FactorioModManWriteTest"))
            {
                MessageBox.Show("The temp path does not seem to be writeable. This is necessary. Please correct.");
                return;
            }
            if (!_isWriteable(txtPathBackup.Text, "FactorioModManWriteTest"))
            {
                MessageBox.Show("The backup path does not seem to be writeable. This is necessary. Please correct.");
                return;
            }


            //specific checks
            if (CheckModsFolder(txtSettingsModPath.Text))
            {
                MessageBox.Show(
                    "The mod folder doesn't exist. If you are certain the path is correct please create an empty folder.");
                return;
            }

            if (ReadFactorioVersion(txtSettingsPathExecuteable.Text) == null)
            {
                MessageBox.Show("Could not fetch Factorio version. Seems to be the wrong executable.");
                return;
            }


            Settings.Default.CachePath = txtPathCache.Text;
            Settings.Default.ModPath = txtSettingsModPath.Text;
            Settings.Default.DownloadTempPath = txtPathTemp.Text;
            Settings.Default.ExecuteablePath = txtSettingsPathExecuteable.Text;
            Settings.Default.ExperimentalFeatures = cbEnableExperimental.Checked;
            Settings.Default.BackupPath = txtPathBackup.Text;
            Settings.Default.OnlineModsSkipThumbnails = cbSkipThumbnails.Checked;


            _blockTabs = false;
            MessageBox.Show("Config seems OK and was saved. Please restart the tool for applying.");
            Environment.Exit(0);
        }

        private void btnModsPathAutodetect_Click(object sender, EventArgs e)
        {
            bool foundExe = false;
            bool foundMods = false;

            #region EXE detection

            #region build possible paths - for check use: possibleExecuteablePaths

            List<string> autobuildExecuteablePaths = new List<string>();

            #region set var values

            List<string> varsPf = new List<string>();
            if (Environment.GetEnvironmentVariable("ProgramFiles") != null)
                varsPf.Add(Environment.GetEnvironmentVariable("ProgramFiles"));
            if (Environment.GetEnvironmentVariable("ProgramFiles(x86)") != null)
                varsPf.Add(Environment.GetEnvironmentVariable("ProgramFiles(x86)"));

            List<string> varsArch = new List<string>();
            varsArch.Add("x64");
            varsArch.Add("x86");

            #endregion

            List<string> possibleExecuteablePaths = new List<string>();
            //maybe there is a better/fast way but for now it's working
            AutodetectExecuteablePathTemplates.ForEach(aP =>
            {
                varsPf.ForEach(pfRep =>
                {
                    varsArch.ForEach(archRep =>
                    {
                        string path = aP;
                        path = path.Replace("%PF%", pfRep);
                        path = path.Replace("%ARCH%", archRep);
                        path = path.Replace("%APPDATA%", Environment.GetEnvironmentVariable("APPDATA"));
                        if (!possibleExecuteablePaths.Contains(path)) possibleExecuteablePaths.Add(path);
                    });
                });
            });

            #endregion

            #region check for existance

            foreach (string possibleExePath in possibleExecuteablePaths)
            {
                try
                {
                    if (Directory.Exists(Path.GetDirectoryName(possibleExePath)))
                    {
                        if (File.Exists(possibleExePath))
                        {
                            //got a match. that's it
                            txtSettingsPathExecuteable.Text = possibleExePath;
                            foundExe = true;
                            break;
                        }
                    }
                }
                catch
                {
                }
            }

            #endregion

            #endregion

            #region MODS detection

            #region build possible paths - for check use: possibleModsPaths 

            List<string> possibleModsPaths = new List<string>();
            AutodetectModsPathTemplates.ForEach(aP =>
            {
                varsPf.ForEach(pfRep =>
                {
                    varsArch.ForEach(archRep =>
                    {
                        string path = aP;
                        path = path.Replace("%PF%", pfRep);
                        path = path.Replace("%ARCH%", archRep);
                        path = path.Replace("%APPDATA%", Environment.GetEnvironmentVariable("APPDATA"));
                        if (!possibleModsPaths.Contains(path)) possibleModsPaths.Add(path);
                    });
                });
            });

            #endregion

            #region check for existance

            foreach (string possibleModPath in possibleModsPaths)
            {
                try
                {
                    if (Directory.Exists(possibleModPath))
                    {
                        if (File.Exists(Path.Combine(possibleModPath, "mod-list.json")))
                        {
                            txtSettingsModPath.Text = possibleModPath;
                            foundMods = true;
                            break;
                        }
                    }
                }
                catch
                {
                }
            }

            #endregion

            #endregion

            //check temp & cache
            if (string.IsNullOrWhiteSpace(txtPathTemp.Text)) txtPathTemp.Text = Path.Combine(@".\temp");
            if (string.IsNullOrWhiteSpace(txtPathCache.Text)) txtPathCache.Text = Path.Combine(@".\cache");

            //depending on founds throw single messages
            if (!foundMods)
                MessageBox.Show(
                    "Mods path couldn't be found automatically. Make sure you've started Factorio at least once.\r\n If you did already and still getting this message try setting manually.");
            if (!foundExe)
                MessageBox.Show(
                    "Executeable path couldn't be found automatically. Most likely did you install Factorio in a custom location. Please set manually.");

            if (foundExe)
            {
                FactorioVersion fv = ReadFactorioVersion(txtSettingsPathExecuteable.Text);
                lblSettingsExeVersion.Text = fv.GetVersionString();
            }
        }

        private bool CheckSettings()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Settings.Default.ExecuteablePath) ||
                    string.IsNullOrWhiteSpace(Settings.Default.ModPath) ||
                    string.IsNullOrWhiteSpace(Settings.Default.BackupPath)) return false;
                if (!File.Exists(Settings.Default.ExecuteablePath) || !Directory.Exists(Settings.Default.ModPath))
                    return false;
                if (ReadFactorioVersion() == null) return false;
                if (!CheckModsFolder()) return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        private bool CheckModsFolder(string path = null)
        {
            if (path == null) path = Settings.Default.ExecuteablePath;
            if (!File.Exists(path)) return false;

            return true;
        }

        private bool CheckExecuteable(string path = null)
        {
            return ReadFactorioVersion(path) != null;
        }


        private FactorioVersion ReadFactorioVersion(string overridePath = null)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.Arguments = "--version";
                p.StartInfo.FileName = overridePath == null ? Settings.Default.ExecuteablePath : overridePath;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                List<string> outputLines =
                    new List<string>(output.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));

                if (p.WaitForExit(5000))
                {
                    //OK
                    _factorioVersion = new FactorioVersion
                    {
                        BinaryVersion = int.Parse(outputLines[1].Substring(outputLines[1].IndexOf(':') + 1)),
                        MapInputVersion = outputLines[1].Substring(outputLines[1].IndexOf(':') + 1).Trim(),
                        MapOutputVersion = outputLines[1].Substring(outputLines[1].IndexOf(':') + 1).Trim()
                    };
                    MatchCollection mc = Regex.Matches(outputLines[0],
                        @"Version: (?<version>.*?) \(Build(?<build>.*?), (?<arch>.*?), (?<issteam>.*?)\)");

                    if (mc.Count == 1)
                    {
                        _factorioVersion.Arch = mc[0].Groups["arch"].Value;
                        _factorioVersion.Version = Version.Parse(mc[0].Groups["version"].Value);
                        _factorioVersion.Build = int.Parse(mc[0].Groups["build"].Value);
                        _factorioVersion.IsSteam = mc[0].Groups["issteam"].Value == "steam";

                        return _factorioVersion;
                    }
                }
            }
            catch (Exception)
            {
            }

            return null;
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_blockTabs) MessageBox.Show("Please provide settings before use.");
            e.Cancel = _blockTabs;
        }

        private void cbEnableExperimental_CheckedChanged(object sender, EventArgs e)
        {
            cbSkipThumbnails.Visible = cbSkipThumbnails.Enabled = cbEnableExperimental.Checked;


            if (cbEnableExperimental.Tag != null) return; //enable initial set without notice
            if (cbEnableExperimental.Checked) //react only on enable
            {
                if (
                    MessageBox.Show(
                        "Activating the experimental features can lead to application crashes. It's not recommended to use them until they are released.\r\n\r\nDo you still want to enable them?",
                        "Experimental features", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    //messagebox denied - disable automatically
                    cbEnableExperimental.Checked = false;
                }
            }
        }
    }
}