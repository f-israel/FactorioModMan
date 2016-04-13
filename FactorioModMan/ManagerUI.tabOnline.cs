using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FactorioModMan.PendingActions;

namespace FactorioModMan
{
    public partial class ManagerUi : Form
    {
        private readonly Dictionary<ListViewItem, ModInfo> _onlineModListMap = new Dictionary<ListViewItem, ModInfo>();

        private readonly OnlineModManager _onlineModManager = new OnlineModManager();

        private bool _onlineAdvancedFilterShown;

        private bool _onlineModVersionSideNotice = true;

        private ModInfo _selectedOnlineMod;

        private int _selectedOnlineModReleaseIdx = -1;

        private void CTOR_TabOnline()
        {
            //some layout fixes - just to ease editing in designer
            lblOnlineAdvancedFilter_Click(null, null); //set advanced filter to hidden
            tabControl.TabPages.RemoveByKey("tabOnlineUI");
            //remove the tab from view - it's just a helper view for the designer
            foreach (Control c in splitContainerOnlineMods.Panel2.Controls) { c.Visible = c.Enabled = false; }

            lblOnlineModsOpenModPage.Visible = false;

            //bind online mod manager events
            _onlineModManager.OnFetchingOnlineProgress += OnlineModManager_OnFetchingOnlineProgress;
            _onlineModManager.OnFetchingOnlineCompleted += OnlineModManager_OnFetchingOnlineCompleted;
            _onlineModManager.OnSearchResult += OnlineModManager_OnSearchResult;

            //some optical corrections
            lblOnlineModsAuthor.Text = lblOnlineModsCategories.Text = lblOnlineModsAuthorWeb.Text = lblOnlineModsGameVersions.Text = "";
        }

        private void OnlineModManager_OnSearchResult(List<ModInfo> result)
        {
            lstOnlineMods.Items.Clear();
            _onlineModListMap.Clear();

            //TODO: push list to UI
            foreach (ModInfo mod in result)
            {
                ListViewItem lvi = lstOnlineMods.Items.Add(mod.Name);
                lvi.SubItems.Add(mod.Releases.Count > 0 ? mod.Releases[0].Version : "N/A");
                lvi.SubItems.Add(mod.Title);


                _onlineModListMap.Add(lvi, mod);
            }
        }

        private void OnlineModManager_OnFetchingOnlineCompleted(List<ModInfo> allMods, List<CategorieInfo> allCategories)
        {
            //build UI in background... prevents flickering & called on UI thread
            OnlineModManager_OnFetchingOnlineProgress(5, 0, "Working...", allMods.Count);
            _onlineModManager.Search("", null); //implies updating list
            //time to switch the ui - needs to be on UI thread
            tabOnlineMods.Controls.Clear();

            foreach (Control c in tabOnlineUI.Controls)
            {
                c.Parent = tabOnlineMods;
                tabOnlineMods.Controls.Add(c);
            }
        }

        private void OnlineModManager_OnFetchingOnlineProgress(int step, int progress, string additional = null, int maxProgress = int.MinValue)
        {
            //special case: step 3, just react on every 5th/10th loop
            if (step == 3 && progress % 10 != 0 && progress != maxProgress) return;
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => { OnlineModManager_OnFetchingOnlineProgress(step, progress, additional, maxProgress); }));
            else
            {
                ProgressBar pgState;
                Label lblState;
                switch (step)
                {
                    case 1:
                        pgState = pgOnlineStep1;
                        lblState = lblOnlineStep1;
                        break;
                    case 2:
                        pgState = pgOnlineStep2;
                        lblState = lblOnlineStep2;
                        break;
                    case 3:
                        pgState = pgOnlineStep3;
                        lblState = lblOnlineStep3;
                        break;
                    case 4:
                        pgState = pgOnlineStep4;
                        lblState = lblOnlineStep4;
                        break;
                    case 5:
                        pgState = pgOnlineStep5;
                        lblState = lblOnlineStep5;
                        break;
                    default:
                        return;
                }

                if (maxProgress != int.MinValue) pgState.Maximum = maxProgress;
                pgState.Value = progress;
                if (additional != null) lblState.Text = additional;
                Application.DoEvents();
            }
        }

        private async void btnOnlineModeEnable_Click(object sender, EventArgs e)
        {
            foreach (Control c in splitContainerOnlineMods.Panel1.Controls) { c.Visible = c.Enabled = false; }
            foreach (Control c in splitContainerOnlineMods.Panel2.Controls) { c.Visible = c.Enabled = true; }
            splitContainerOnlineMods.SplitterDistance = 0;

            await _onlineModManager.StartOnline();
            btnOnlineModeEnable.Enabled = false;
        }


        private void lstOnlineMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOnlineMods.SelectedItems.Count > 0)
            {
                ListViewItem selected = lstOnlineMods.SelectedItems[0];
                _selectedOnlineMod = _onlineModListMap[selected];

                OnlineModsRefreshModDetails(_selectedOnlineMod, -1);
            }
            else
            { _selectedOnlineMod = null; }
        }

        private void cbOnlineMatchingVersion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOnlineModsFilterMatchingVersion.Checked)
            {
                if (_onlineModVersionSideNotice)
                {
                    MessageBox.Show("Some mods have invalid values so this is no warranty it will work. While testing I had some cases where the version matched but the mod was still faulty.", "Side notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _onlineModVersionSideNotice = false;
                }
                _onlineModManager.Search(txtOnlineModsSearch.Text, _factorioVersion.Version);
            }
            else _onlineModManager.Search(txtOnlineModsSearch.Text, null);
        }

        private void lblOnlineAdvancedFilter_Click(object sender, EventArgs e)
        {
            //smallest: 25
            int min = 25;
            int max = 105;
            for (int i = min; i < max; i = i + 10)
            {
                splitContainerOnlineFilter.SplitterDistance = _onlineAdvancedFilterShown ? max - i : i;
                Application.DoEvents();
                //Thread.Sleep(5);
            }

            lblOnlineAdvancedFilter.Text = _onlineAdvancedFilterShown ? "Hide advanced" : "Show advanced";
            _onlineAdvancedFilterShown = !_onlineAdvancedFilterShown;
        }


        private void txtOnlineSearch_TextChanged(object sender, EventArgs e)
        {
            _onlineModManager.Search(txtOnlineModsSearch.Text, null);
        }


        private void ResizeOnlineModList()
        {
            lstOnlineMods.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void pbOnlineModsThumbnail_Click(object sender, EventArgs e)
        {
            PictureViewer viewer = new PictureViewer { ShownImage = pbOnlineModsThumbnail.Image };
            viewer.ShowDialog();
            viewer.Dispose();
        }


        private void btnOnlineModsInstallUpdate_Click(object sender, EventArgs e)
        {
            LocalModManager.ModState currentModState = _localModManager.GetState(_selectedOnlineMod);

            switch (currentModState)
            {
                case LocalModManager.ModState.NotInstalled:
                    OnlineModBuildAction(PendingChangeBase.PendingAction.Download); //install from online mods always imply downloading
                    OnlineModBuildAction(PendingChangeBase.PendingAction.Install);
                    break;
                case LocalModManager.ModState.InstalledDisabled:
                    break;
                case LocalModManager.ModState.InstalledEnabled:
                    break;
            }
            
            //TODO: decide if (RE)INSTALL or UPDATE

            throw new NotImplementedException();
            //  PendingChanges.AddInstall(_onlineModManager.CompleteModInfo(_selectedOnlineMod), releases[0]);
        }


        private void btnOnlineModsUninstall_Click(object sender, EventArgs e)
        {
            OnlineModBuildAction(PendingChangeBase.PendingAction.Uninstall);

            if (_selectedOnlineMod != null) { _localModManager.Uninstall(_onlineModManager.CompleteModInfo(_selectedOnlineMod)); }
        }

        private void btnOnlineModsDownloadAsZip_Click(object sender, EventArgs e)
        {
            OnlineModBuildAction(PendingChangeBase.PendingAction.Download);
        }

        private void OnlineModBuildAction(PendingChangeBase.PendingAction pendingAction)
        {
            if (_selectedOnlineMod == null)
            {
                MessageBox.Show("Please select a mod beforehand");
                return;
            }
            if (_selectedOnlineModReleaseIdx == -1)
            {
                MessageBox.Show("Please specify a release version.");
                return;
            }
            switch (pendingAction)
            {
                case PendingChangeBase.PendingAction.Download:
                    PendingChanges.AddDownload(_selectedOnlineMod, _selectedOnlineModReleaseIdx, _localModManager.GetDownloadPath(_selectedOnlineMod, _selectedOnlineModReleaseIdx));
                    break;
                case PendingChangeBase.PendingAction.Install:

                    PendingChanges.AddDownload(_selectedOnlineMod, _selectedOnlineModReleaseIdx, _localModManager.GetDownloadPath(_selectedOnlineMod, _selectedOnlineModReleaseIdx));
                    PendingChanges.AddInstall(_selectedOnlineMod, _localModManager.GetDownloadPath(_selectedOnlineMod, _selectedOnlineModReleaseIdx));
                    break;
                case PendingChangeBase.PendingAction.Uninstall:
                    PendingChanges.AddUninstall(_selectedOnlineMod);
                    break;
                case PendingChangeBase.PendingAction.Update:
                    PendingChanges.AddDownload(_selectedOnlineMod, _selectedOnlineModReleaseIdx, _localModManager.GetDownloadPath(_selectedOnlineMod, _selectedOnlineModReleaseIdx));
                    PendingChanges.AddUninstall(_selectedOnlineMod);
                    PendingChanges.AddInstall(_selectedOnlineMod, _localModManager.GetDownloadPath(_selectedOnlineMod, _selectedOnlineModReleaseIdx));
                    break;
            }
        }

        private void ddOnlineModsReleaseVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnlineModsRefreshModDetails(_selectedOnlineMod, ddOnlineModsReleaseVersions.SelectedIndex);
            _selectedOnlineModReleaseIdx = ddOnlineModsReleaseVersions.SelectedIndex - 1;
        }

        private void OnlineModsRefreshModDetails(ModInfo mod, int specificRelease)
        {
            List<string> modGameVersions = new List<string>();
            List<ModInfo.ReleaseInfo> releaseInfos = new List<ModInfo.ReleaseInfo>();

            if (specificRelease < 1) //specificRelease == 0 => "any" selected, show summarized infos
            {
                releaseInfos.AddRange(mod.Releases);
                if (specificRelease == -1) //-1 => mod selected first time, so rebuild the release list
                {
                    ddOnlineModsReleaseVersions.Items.Clear();
                    ddOnlineModsReleaseVersions.Items.Add("(any)");
                    ddOnlineModsReleaseVersions.SelectedIndex = 0;
                    foreach (ModInfo.ReleaseInfo info in mod.Releases) { ddOnlineModsReleaseVersions.Items.Add(info); }
                }
            }
            else
            { releaseInfos.Add(mod.Releases[specificRelease - 1]); }

            foreach (ModInfo.ReleaseInfo releaseInfo in releaseInfos) { if (releaseInfo.Game_Versions != null) { modGameVersions.AddRange(releaseInfo.Game_Versions); } }
            modGameVersions = modGameVersions.Distinct().ToList();
            modGameVersions.Sort();
            if (modGameVersions.Count > 0) lblOnlineModsGameVersions.Text = string.Join(", ", modGameVersions);
            else lblOnlineModsGameVersions.Text = "(no versions provided)";

            lblOnlineModsDescription.Text = mod.Description;

            lblOnlineModsAuthor.Links.Clear();
            lblOnlineModsAuthor.Text = mod.Author;
            if (!string.IsNullOrWhiteSpace(mod.Contact))
            {
                lblOnlineModsAuthor.Text += $" ({mod.Contact})";
                if (mod.Contact.Contains("@"))
                {
                    //should be an email adress
                    lblOnlineModsAuthor.Links.Add(mod.Author.Length + 2, mod.Contact.Length, "mailto://" + mod.Contact);
                }
                else
                {
                    //here just a simple http link
                    lblOnlineModsAuthor.Links.Add(mod.Author.Length + 2, mod.Contact.Length, mod.Contact.ToLower().Contains("http") ? mod.Contact : "http://" + mod.Contact); //just a little kind-of security fix
                }
            }

            lblOnlineModsCategories.Text = string.Join(", ", mod.Categories);
            lblOnlineModsAuthorWeb.Text = mod.Homepage;
            lblOnlineModsAuthorWeb.Links.Clear();
            lblOnlineModsAuthorWeb.Links.Add(0, lblOnlineModsAuthorWeb.Text.Length, mod.Homepage.ToLower().Contains("http") ? mod.Homepage : "http://" + mod.Homepage);

            lblOnlineModsOpenModPage.Visible = true;
            lblOnlineModsOpenModPage.Links.Clear();
            lblOnlineModsOpenModPage.Links.Add(0, lblOnlineModsOpenModPage.Text.Length, mod.Url.ToLower().Contains("http") ? mod.Url : "http://" + mod.Url);


            pbOnlineModsThumbnail.Image = mod.Image;
        }
    }
}