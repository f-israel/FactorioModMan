using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FactorioModMan.Properties;
using Ionic.Zip;

namespace FactorioModMan
{
    public partial class ManagerUi : Form
    {
        private readonly Dictionary<ListViewItem, ModInfo> _localModListMap = new Dictionary<ListViewItem, ModInfo>();

        private LocalModManager _localModManager;

        private void CTOR_TabLocalMods()
        {
        }

        private void RefreshLocalModList()
        {
            //do inits
            _localModManager = new LocalModManager(Settings.Default.ModPath, Settings.Default.BackupPath);
            foreach (ModInfo mod in _localModManager.ReadFolder())
            {
                ListViewItem lvi = lstLocalMods.Items.Add(mod.ToListViewItem(_localModManager.GetInstalledModVersion(mod), _localModManager.GetState(mod)));
                _localModListMap.Add(lvi, mod);
            }
        }

        private void btnSettingsTemp_Click(object sender, EventArgs e)
        {
            if (openfolderTemp.ShowDialog() == DialogResult.OK) { txtPathTemp.Text = openfolderTemp.SelectedPath; }
        }

        private void btnSettingsCache_Click(object sender, EventArgs e)
        {
            if (openfolderCache.ShowDialog() == DialogResult.OK) { txtPathCache.Text = openfolderCache.SelectedPath; }
        }

        private bool _isWriteable(params string[] pathElements)
        {
            try
            {
                string testFilename = Path.Combine(pathElements);
                File.WriteAllText(testFilename, "FactorioModManWriteTest");
                File.Delete(testFilename);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool _isValidPath(string path)
        {
            try
            {
                Path.GetFullPath(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private async void btnLocalModsRestore_Click(object sender, EventArgs e)
        {
            openfileLocalModsRestore.ShowReadOnly = true;
            if (openfileLocalModsRestore.ShowDialog() == DialogResult.OK)
            {
                await _localModManager.Restore(openfileLocalModsRestore.FileName, ev => HandleBackupProgress(ev, true), HandleRestoreProgress);
                //now rescan the local mods
                RefreshLocalModList();
            }
        }

        private async void btnLocalModsBackup_Click(object sender, EventArgs e)
        {

            await _localModManager.Backup(ev => HandleBackupProgress(ev, false));
        }

        private void HandleRestoreProgress(LocalModManager.RestoreProgressEventArgs obj)
        {
            panelLocalModsBackupRestoreProgress.Invoke(new MethodInvoker(() =>
            {
                if (pgLocalModsBackupRestoreProgress.Value > pgLocalModsBackupRestoreProgress.Maximum) pgLocalModsBackupRestoreProgress.Value = pgLocalModsBackupRestoreProgress.Minimum;
                pgLocalModsBackupRestoreProgress.Maximum = obj.max;
                pgLocalModsBackupRestoreProgress.Value = obj.val;
                if (obj.txt != null) lblLocalModsBackupRestoreProgress.Text = obj.txt;

                if (obj.hideProgress)
                {
                    lstLocalMods.Visible = true;
                    flowpanelLocalMods.Visible = true;
                    panelLocalModsBackupRestoreProgress.Visible = false;
                }
                else {
                    lstLocalMods.Visible = false;
                    flowpanelLocalMods.Visible = false;
                    panelLocalModsBackupRestoreProgress.Visible = true;
                }

            }));
        }

        private void HandleBackupProgress(SaveProgressEventArgs saveProgressEventArgs, bool suppressMessageBoxes)
        {
            //as we come from await context we need to invoke
            panelLocalModsBackupRestoreProgress.Invoke(new MethodInvoker(() =>
            {

                switch (saveProgressEventArgs.EventType)
                {
                    case ZipProgressEventType.Saving_Started:
                        lstLocalMods.Visible = false;
                        panelLocalModsBackupRestoreProgress.Visible = true;
                        pgLocalModsBackupRestoreProgress.Maximum = 100;
                        pgLocalModsBackupRestoreProgress.Value = 0;

                        break;
                    case ZipProgressEventType.Saving_AfterWriteEntry:
                        pgLocalModsBackupRestoreProgress.Maximum = saveProgressEventArgs.EntriesTotal;
                        pgLocalModsBackupRestoreProgress.Value = saveProgressEventArgs.EntriesSaved;
                        try
                        {
                            string backingUpMod = Path.GetDirectoryName(saveProgressEventArgs.CurrentEntry.FileName).Split(Path.DirectorySeparatorChar)[0];
                            lblLocalModsBackupRestoreProgress.Text = $"Saving: {backingUpMod}";
                        }
                        catch
                        {
                            // ignored
                        }
                        break;
                    case ZipProgressEventType.Saving_Completed:
                        lstLocalMods.Visible = true;
                        panelLocalModsBackupRestoreProgress.Visible = false;
                        if (!suppressMessageBoxes) MessageBox.Show("Backup completed");
                        break;
                    case ZipProgressEventType.Error_Saving:
                        lstLocalMods.Visible = true;
                        pgLocalModsBackupRestoreProgress.Maximum = 100;
                        pgLocalModsBackupRestoreProgress.Value = 0;
                        panelLocalModsBackupRestoreProgress.Visible = false;
                        if (!suppressMessageBoxes) MessageBox.Show("Backup failed. Please try again.");
                        break;
                    default:
                        break;
                }
            }));
        }

        private void lstInstalledMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModInfo selectedMod = null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _localModManager.ReadFolder(true);
        }

        private void ResizeInstalledModList()
        {
            lstLocalMods.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}