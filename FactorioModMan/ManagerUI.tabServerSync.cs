using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using FactorioModMan.Properties;

namespace FactorioModMan
{
    public partial class ManagerUi : Form
    {
        private void CTOR_TabServerSync()
        {
            //check for experimental feature setting. if disable remove the tabs.
            if (!Settings.Default.ExperimentalFeatures)
            {
                foreach (string expTabKey in ExperimentalTabs)
                {
                    tabControl.TabPages.RemoveByKey(expTabKey);
                }
            }

            //hide & disable server sync sub view
            foreach (Control c in splitContainerSubServerSync.Panel2.Controls) c.Visible = c.Enabled = false;
        }

        private async void btnServerSyncSyncToLocal_Click(object sender, EventArgs e)
        {
            if (_onlineModListMap == null || _onlineModListMap.Count == 0)
            {
                MessageBox.Show(
                    "Before you can use this feature please enable the online feature. Please try again after the sync is done.");
                tabControl.SelectTab("tabOnlineMods");
            }
            else
            {
                //online sync was done

                if (DialogResult.Yes == MessageBox.Show("" +
                                                        "This feature is HIGHLY experimental! The following steps will be taken:\r\n" +
                                                        "- Backup all local installed mods\r\n" +
                                                        "- Download all server mods from factoriomods.com\r\n" +
                                                        "- Remove local mods which are not listen in server and install missing ones\r\n\r\n" +
                                                        "Are you sure you want to continue?", "Confirmation",
                    MessageBoxButtons.YesNo))
                {
                    //1. backup
                    //2. download missing ones
                    //3. remove not needed ones
                    //4. install downloaded
                }
            }
        }

        private void btnServerSyncConnect_Click(object sender, EventArgs e)
        {
            tabControl.Enabled = false;
            lstServerSyncMods.Items.Clear();
            //txtServerSyncHost.Enabled = txtServerSyncPort.Enabled = btnServerSyncConnect.Enabled = false;
            ushort port;
            if (ushort.TryParse(txtServerSyncPort.Text, out port) || port < 1 || port > 65535)
            {
                FactorioNetwork fn = new FactorioNetwork();
                IPAddress ip;
                lblServerSyncState.Text = "Resolving host...";
                if (fn.TryResolveToIp(txtServerSyncHost.Text, out ip))
                {
                    lblServerSyncState.Text = "Requesting info...";
                    ServerInfo si = fn.RequestModlistFromServer(ip, port);
                    if (si.Success)
                    {
                        lblServerSyncState.Text = "Success";
                        //update form
                        foreach (Control c in splitContainerSubServerSync.Panel2.Controls) c.Visible = c.Enabled = true;
                        FillServerSyncResult(si);
                    }
                }
                else
                {
                    MessageBox.Show("Could not resolve host. Maybe misstyped?", "Connect error");
                }
            }
            else
            {
                MessageBox.Show(
                    "The provided udp port is not valid. It need to be between 1 and 65535. The default port is 34197.",
                    "Connect error");
            }
            tabControl.Enabled = true;
            //txtServerSyncHost.Enabled = txtServerSyncPort.Enabled = btnServerSyncConnect.Enabled = true;
        }

        private void CheckServerSyncButtonState(object sender, EventArgs e)
        {
            ushort notneeded;
            btnServerSyncConnect.Enabled = !string.IsNullOrWhiteSpace(txtServerSyncHost.Text) &&
                                           ushort.TryParse(txtServerSyncPort.Text, out notneeded);
        }

        private void FillServerSyncResult(ServerInfo si)
        {
            lstServerSyncMods.Enabled = btnServerSyncSyncToLocal.Enabled = false;
            foreach (ServerInfo.ServerModInfo modinfo in si.ActiveMods)
            {
                LocalModManager.ModSyncState state = _localModManager.CompareToLocal(modinfo);
                lstServerSyncMods.Items.Add(new ListViewItem(new[] { modinfo.Name, modinfo.Version.ToString(3), state.ToString() }));

                int row = lstServerSyncMods.Items.Count - 1;
                int col = 3;

                FlowLayoutPanel btnHolder = new FlowLayoutPanel();
                if (state != LocalModManager.ModSyncState.Installed)
                {
                    string installBtnText = "";
                    switch (state)
                    {
                        case LocalModManager.ModSyncState.ServerOutdated:
                            installBtnText = "Downgrade";
                            break;
                        case LocalModManager.ModSyncState.LocalOutdated:
                            installBtnText = "Update";
                            break;
                        case LocalModManager.ModSyncState.NotInstalled:
                            installBtnText = "Install";
                            break;
                    }
                    Button installBtn = new Button { Text = installBtnText };
                    installBtn.Click += (sender, e) =>
                    {
                        #region install btn event

                        if (modinfo.Name.ToLower() == "base")
                        {
                            MessageBox.Show("The base mod can not be updated with the mod manager. Please update the game and retry.");
                            return;
                        }

                        if (!_onlineModManager.SyncDone)
                        {
                            MessageBox.Show("Before you can use this feature please enable the online feature. Please try again after the sync is done.");
                            return;
                        }

                        //this step would be unnecessary as it is implied by FindReleaseInfoByNameAndVersion
                        //still it's here just for informing the user about the real failed case, if any
                        ModInfo mod = _onlineModManager.FindModByName(modinfo.Name);
                        if (mod == null)
                        {
                            //the online mod manager didn't find the mod. most likely it's not available.
                            MessageBox.Show("We couldn't find the mod on factoriomods.com. We can't install this one. Please ask the server admin to provide you with a copy.");
                            return;
                        }

                        ModInfo.ReleaseInfo? ri = _onlineModManager.FindReleaseInfoByNameAndVersion(modinfo.Name, modinfo.Version);
                        if (!ri.HasValue)
                        {
                            //the online mod manager found the mod but not the requested release. can be many cases why.
                            MessageBox.Show("We found the mod on factoriomods.com but not the requested release version. We are not able to install. Please ask the server admin to provide you with a copy.");
                            return;
                        }

                        //if we are here the checks are complete and ri has value.
                        string tmpDownloadName = _localModManager.GetDownloadPath(mod, _selectedOnlineModReleaseIdx);
                        PendingChanges.AddDownload(mod, mod.Releases.IndexOf(ri.Value), tmpDownloadName);
                        PendingChanges.AddInstall(mod, tmpDownloadName);
                        #endregion
                    };
                    if (modinfo.Name.ToLower() == "base") installBtn.BackColor = Color.DarkGray;
                    btnHolder.Controls.Add(MakeButtonCompatible(installBtn));
                }
                if (modinfo.Name.ToLower() != "base")
                {
                    Button downloadBtn = new Button { Text = "Download" };
                    downloadBtn.Click += (sender, e) => { }; //TODO
                    Button browseBtn = new Button { Text = "Show on web" };
                    browseBtn.Click += (sender, e) => { }; //TODO
                    btnHolder.Controls.Add(MakeButtonCompatible(downloadBtn));
                    btnHolder.Controls.Add(MakeButtonCompatible(browseBtn));
                }
                lstServerSyncMods.AddEmbeddedControl(btnHolder, col, row);
                ResizeServerSyncList();
            }
            lstServerSyncMods.Enabled = btnServerSyncSyncToLocal.Enabled = true;
        }

        private void ResizeServerSyncList()
        {
            lstServerSyncMods.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            int lastColWidth = lstServerSyncMods.Width - 25;
            for (int i = 0; i < lstServerSyncMods.Columns.Count - 1; i++)
            {
                lastColWidth -= lstServerSyncMods.Columns[i].Width;
            }
            lstServerSyncMods.Columns[lstServerSyncMods.Columns.Count - 1].Width = lastColWidth;
        }
    }
}