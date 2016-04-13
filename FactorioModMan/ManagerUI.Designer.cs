using System;

namespace FactorioModMan
{
    partial class ManagerUi
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerUi));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPending = new System.Windows.Forms.TabPage();
            this.btnPendingChangesApplyAll = new System.Windows.Forms.Button();
            this.lstPendingChanges = new ListViewEx();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabLocalMods = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panelLocalModsBackupRestoreProgress = new System.Windows.Forms.Panel();
            this.lblLocalModsBackupRestoreProgress = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pgLocalModsBackupRestoreProgress = new System.Windows.Forms.ProgressBar();
            this.lstLocalMods = new ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowpanelLocalMods = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLocalModsReload = new System.Windows.Forms.Button();
            this.btnLocalModsBackup = new System.Windows.Forms.Button();
            this.btnLocalModsRestore = new System.Windows.Forms.Button();
            this.tabOnlineMods = new System.Windows.Forms.TabPage();
            this.splitContainerOnlineMods = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOnlineModeEnable = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOnlineStep3 = new System.Windows.Forms.Label();
            this.lblOnlineStep2 = new System.Windows.Forms.Label();
            this.lblOnlineStep1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pgOnlineStep1 = new System.Windows.Forms.ProgressBar();
            this.pgOnlineStep2 = new System.Windows.Forms.ProgressBar();
            this.pgOnlineStep3 = new System.Windows.Forms.ProgressBar();
            this.pgOnlineStep5 = new System.Windows.Forms.ProgressBar();
            this.lblOnlineStep5 = new System.Windows.Forms.Label();
            this.pgOnlineStep4 = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblOnlineStep4 = new System.Windows.Forms.Label();
            this.tabOnlineUI = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerOnlineFilter = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOnlineAdvancedFilter = new System.Windows.Forms.Label();
            this.txtOnlineModsSearch = new System.Windows.Forms.TextBox();
            this.cbOnlineModsFilterMatchingVersion = new System.Windows.Forms.CheckBox();
            this.lstOnlineMods = new ListViewEx();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label22 = new System.Windows.Forms.Label();
            this.ddOnlineModsReleaseVersions = new System.Windows.Forms.ComboBox();
            this.lblOnlineModsGameVersions = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pbOnlineModsThumbnail = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblOnlineModsCategories = new System.Windows.Forms.Label();
            this.lblOnlineModsAuthorWeb = new System.Windows.Forms.LinkLabel();
            this.lblOnlineModsAuthor = new System.Windows.Forms.LinkLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblOnlineModsOpenModPage = new System.Windows.Forms.LinkLabel();
            this.lblOnlineModsDescription = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOnlineModsDownloadAsZip = new System.Windows.Forms.Button();
            this.btnOnlineModsInstallUpdate = new System.Windows.Forms.Button();
            this.btnOnlineDownloadAsZip = new System.Windows.Forms.Button();
            this.tabServerSync = new System.Windows.Forms.TabPage();
            this.splitContainerServerFinder = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.splitContainerSubServerSync = new System.Windows.Forms.SplitContainer();
            this.btnServerSyncSyncToLocal = new System.Windows.Forms.Button();
            this.btnServerSyncConnect = new System.Windows.Forms.Button();
            this.lblServerSyncState = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtServerSyncPort = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtServerSyncHost = new System.Windows.Forms.TextBox();
            this.lstServerSyncMods = new ListViewEx();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.cbSkipThumbnails = new System.Windows.Forms.CheckBox();
            this.btnSettingsBackup = new System.Windows.Forms.Button();
            this.txtPathBackup = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbEnableExperimental = new System.Windows.Forms.CheckBox();
            this.btnSettingsCache = new System.Windows.Forms.Button();
            this.txtPathCache = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSettingsTemp = new System.Windows.Forms.Button();
            this.txtPathTemp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSettingsAutodetect = new System.Windows.Forms.Button();
            this.btnSettingsModPath = new System.Windows.Forms.Button();
            this.txtSettingsModPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSettingsExeVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.btnSettingsFactorieExePath = new System.Windows.Forms.Button();
            this.txtSettingsPathExecuteable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openfileSettingsExecuteable = new System.Windows.Forms.OpenFileDialog();
            this.openfolderSettingsModPath = new System.Windows.Forms.FolderBrowserDialog();
            this.openfolderTemp = new System.Windows.Forms.FolderBrowserDialog();
            this.openfolderCache = new System.Windows.Forms.FolderBrowserDialog();
            this.openfileLocalModsRestore = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPending.SuspendLayout();
            this.tabLocalMods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panelLocalModsBackupRestoreProgress.SuspendLayout();
            this.flowpanelLocalMods.SuspendLayout();
            this.tabOnlineMods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOnlineMods)).BeginInit();
            this.splitContainerOnlineMods.Panel1.SuspendLayout();
            this.splitContainerOnlineMods.Panel2.SuspendLayout();
            this.splitContainerOnlineMods.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabOnlineUI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOnlineFilter)).BeginInit();
            this.splitContainerOnlineFilter.Panel1.SuspendLayout();
            this.splitContainerOnlineFilter.Panel2.SuspendLayout();
            this.splitContainerOnlineFilter.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOnlineModsThumbnail)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.tabServerSync.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerServerFinder)).BeginInit();
            this.splitContainerServerFinder.Panel1.SuspendLayout();
            this.splitContainerServerFinder.Panel2.SuspendLayout();
            this.splitContainerServerFinder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSubServerSync)).BeginInit();
            this.splitContainerSubServerSync.Panel1.SuspendLayout();
            this.splitContainerSubServerSync.Panel2.SuspendLayout();
            this.splitContainerSubServerSync.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPending);
            this.tabControl.Controls.Add(this.tabLocalMods);
            this.tabControl.Controls.Add(this.tabOnlineMods);
            this.tabControl.Controls.Add(this.tabOnlineUI);
            this.tabControl.Controls.Add(this.tabServerSync);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(935, 611);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // tabPending
            // 
            this.tabPending.Controls.Add(this.btnPendingChangesApplyAll);
            this.tabPending.Controls.Add(this.lstPendingChanges);
            this.tabPending.Location = new System.Drawing.Point(4, 22);
            this.tabPending.Name = "tabPending";
            this.tabPending.Size = new System.Drawing.Size(927, 585);
            this.tabPending.TabIndex = 3;
            this.tabPending.Text = "Pending changes";
            this.tabPending.UseVisualStyleBackColor = true;
            // 
            // btnPendingChangesApplyAll
            // 
            this.btnPendingChangesApplyAll.AutoSize = true;
            this.btnPendingChangesApplyAll.Location = new System.Drawing.Point(4, 450);
            this.btnPendingChangesApplyAll.Name = "btnPendingChangesApplyAll";
            this.btnPendingChangesApplyAll.Size = new System.Drawing.Size(128, 23);
            this.btnPendingChangesApplyAll.TabIndex = 1;
            this.btnPendingChangesApplyAll.Text = "Apply pending changes";
            this.btnPendingChangesApplyAll.UseVisualStyleBackColor = true;
            this.btnPendingChangesApplyAll.Click += new System.EventHandler(this.btnPendingChangesApplyAll_Click);
            // 
            // lstPendingChanges
            // 
            this.lstPendingChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader17,
            this.columnHeader16});
            this.lstPendingChanges.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstPendingChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lstPendingChanges.FullRowSelect = true;
            this.lstPendingChanges.GridLines = true;
            this.lstPendingChanges.Location = new System.Drawing.Point(0, 0);
            this.lstPendingChanges.Margin = new System.Windows.Forms.Padding(2);
            this.lstPendingChanges.Name = "lstPendingChanges";
            this.lstPendingChanges.Size = new System.Drawing.Size(927, 444);
            this.lstPendingChanges.TabIndex = 0;
            this.lstPendingChanges.UseCompatibleStateImageBehavior = false;
            this.lstPendingChanges.View = System.Windows.Forms.View.Details;
            this.lstPendingChanges.SelectedIndexChanged += new System.EventHandler(this.lstPendingChanges_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "#";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Action";
            this.columnHeader10.Width = 107;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Info";
            this.columnHeader11.Width = 301;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "State";
            this.columnHeader17.Width = 103;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "";
            this.columnHeader16.Width = 89;
            // 
            // tabLocalMods
            // 
            this.tabLocalMods.Controls.Add(this.splitContainer2);
            this.tabLocalMods.Location = new System.Drawing.Point(4, 22);
            this.tabLocalMods.Name = "tabLocalMods";
            this.tabLocalMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocalMods.Size = new System.Drawing.Size(927, 585);
            this.tabLocalMods.TabIndex = 0;
            this.tabLocalMods.Text = "Installed mods";
            this.tabLocalMods.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panelLocalModsBackupRestoreProgress);
            this.splitContainer2.Panel1.Controls.Add(this.lstLocalMods);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowpanelLocalMods);
            this.splitContainer2.Size = new System.Drawing.Size(921, 579);
            this.splitContainer2.SplitterDistance = 542;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 2;
            // 
            // panelLocalModsBackupRestoreProgress
            // 
            this.panelLocalModsBackupRestoreProgress.Controls.Add(this.lblLocalModsBackupRestoreProgress);
            this.panelLocalModsBackupRestoreProgress.Controls.Add(this.label19);
            this.panelLocalModsBackupRestoreProgress.Controls.Add(this.pgLocalModsBackupRestoreProgress);
            this.panelLocalModsBackupRestoreProgress.Location = new System.Drawing.Point(253, 177);
            this.panelLocalModsBackupRestoreProgress.Name = "panelLocalModsBackupRestoreProgress";
            this.panelLocalModsBackupRestoreProgress.Size = new System.Drawing.Size(345, 84);
            this.panelLocalModsBackupRestoreProgress.TabIndex = 3;
            this.panelLocalModsBackupRestoreProgress.Visible = false;
            // 
            // lblLocalModsBackupRestoreProgress
            // 
            this.lblLocalModsBackupRestoreProgress.Location = new System.Drawing.Point(4, 66);
            this.lblLocalModsBackupRestoreProgress.Name = "lblLocalModsBackupRestoreProgress";
            this.lblLocalModsBackupRestoreProgress.Size = new System.Drawing.Size(338, 13);
            this.lblLocalModsBackupRestoreProgress.TabIndex = 4;
            this.lblLocalModsBackupRestoreProgress.Text = "Initializing...";
            this.lblLocalModsBackupRestoreProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(129, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Backup/Restore progress";
            // 
            // pgLocalModsBackupRestoreProgress
            // 
            this.pgLocalModsBackupRestoreProgress.Location = new System.Drawing.Point(7, 30);
            this.pgLocalModsBackupRestoreProgress.Name = "pgLocalModsBackupRestoreProgress";
            this.pgLocalModsBackupRestoreProgress.Size = new System.Drawing.Size(323, 23);
            this.pgLocalModsBackupRestoreProgress.TabIndex = 2;
            // 
            // lstLocalMods
            // 
            this.lstLocalMods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader18,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstLocalMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLocalMods.FullRowSelect = true;
            this.lstLocalMods.GridLines = true;
            this.lstLocalMods.Location = new System.Drawing.Point(0, 0);
            this.lstLocalMods.Name = "lstLocalMods";
            this.lstLocalMods.Size = new System.Drawing.Size(921, 542);
            this.lstLocalMods.TabIndex = 1;
            this.lstLocalMods.UseCompatibleStateImageBehavior = false;
            this.lstLocalMods.View = System.Windows.Forms.View.Details;
            this.lstLocalMods.SelectedIndexChanged += new System.EventHandler(this.lstInstalledMods_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Internal name";
            this.columnHeader1.Width = 132;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Version";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "State";
            this.columnHeader2.Width = 72;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Title";
            this.columnHeader3.Width = 168;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 347;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Author";
            // 
            // flowpanelLocalMods
            // 
            this.flowpanelLocalMods.Controls.Add(this.btnLocalModsReload);
            this.flowpanelLocalMods.Controls.Add(this.btnLocalModsBackup);
            this.flowpanelLocalMods.Controls.Add(this.btnLocalModsRestore);
            this.flowpanelLocalMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowpanelLocalMods.Location = new System.Drawing.Point(0, 0);
            this.flowpanelLocalMods.Name = "flowpanelLocalMods";
            this.flowpanelLocalMods.Size = new System.Drawing.Size(921, 36);
            this.flowpanelLocalMods.TabIndex = 0;
            // 
            // btnLocalModsReload
            // 
            this.btnLocalModsReload.Location = new System.Drawing.Point(3, 3);
            this.btnLocalModsReload.Name = "btnLocalModsReload";
            this.btnLocalModsReload.Size = new System.Drawing.Size(75, 23);
            this.btnLocalModsReload.TabIndex = 3;
            this.btnLocalModsReload.Text = "reload";
            this.btnLocalModsReload.UseVisualStyleBackColor = true;
            this.btnLocalModsReload.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLocalModsBackup
            // 
            this.btnLocalModsBackup.Location = new System.Drawing.Point(84, 3);
            this.btnLocalModsBackup.Name = "btnLocalModsBackup";
            this.btnLocalModsBackup.Size = new System.Drawing.Size(75, 23);
            this.btnLocalModsBackup.TabIndex = 4;
            this.btnLocalModsBackup.Text = "full backup";
            this.btnLocalModsBackup.UseVisualStyleBackColor = true;
            this.btnLocalModsBackup.Click += new System.EventHandler(this.btnLocalModsBackup_Click);
            // 
            // btnLocalModsRestore
            // 
            this.btnLocalModsRestore.Location = new System.Drawing.Point(165, 3);
            this.btnLocalModsRestore.Name = "btnLocalModsRestore";
            this.btnLocalModsRestore.Size = new System.Drawing.Size(75, 23);
            this.btnLocalModsRestore.TabIndex = 5;
            this.btnLocalModsRestore.Text = "restore";
            this.btnLocalModsRestore.UseVisualStyleBackColor = true;
            this.btnLocalModsRestore.Click += new System.EventHandler(this.btnLocalModsRestore_Click);
            // 
            // tabOnlineMods
            // 
            this.tabOnlineMods.Controls.Add(this.splitContainerOnlineMods);
            this.tabOnlineMods.Location = new System.Drawing.Point(4, 22);
            this.tabOnlineMods.Name = "tabOnlineMods";
            this.tabOnlineMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabOnlineMods.Size = new System.Drawing.Size(927, 585);
            this.tabOnlineMods.TabIndex = 1;
            this.tabOnlineMods.Text = "Online mods";
            this.tabOnlineMods.UseVisualStyleBackColor = true;
            // 
            // splitContainerOnlineMods
            // 
            this.splitContainerOnlineMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOnlineMods.Location = new System.Drawing.Point(3, 3);
            this.splitContainerOnlineMods.Name = "splitContainerOnlineMods";
            this.splitContainerOnlineMods.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOnlineMods.Panel1
            // 
            this.splitContainerOnlineMods.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerOnlineMods.Panel1.Controls.Add(this.label6);
            this.splitContainerOnlineMods.Panel1.Controls.Add(this.btnOnlineModeEnable);
            this.splitContainerOnlineMods.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitContainerOnlineMods.Panel2
            // 
            this.splitContainerOnlineMods.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerOnlineMods.Size = new System.Drawing.Size(921, 579);
            this.splitContainerOnlineMods.SplitterDistance = 113;
            this.splitContainerOnlineMods.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(754, 41);
            this.label6.TabIndex = 7;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // btnOnlineModeEnable
            // 
            this.btnOnlineModeEnable.Location = new System.Drawing.Point(278, 58);
            this.btnOnlineModeEnable.Name = "btnOnlineModeEnable";
            this.btnOnlineModeEnable.Size = new System.Drawing.Size(192, 23);
            this.btnOnlineModeEnable.TabIndex = 6;
            this.btnOnlineModeEnable.Text = "Ok, I understand.";
            this.btnOnlineModeEnable.UseVisualStyleBackColor = true;
            this.btnOnlineModeEnable.Click += new System.EventHandler(this.btnOnlineModeEnable_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.73913F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.26087F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 463F));
            this.tableLayoutPanel1.Controls.Add(this.lblOnlineStep3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOnlineStep2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblOnlineStep1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pgOnlineStep1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pgOnlineStep2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pgOnlineStep3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pgOnlineStep5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblOnlineStep5, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.pgOnlineStep4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblOnlineStep4, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 107);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblOnlineStep3
            // 
            this.lblOnlineStep3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOnlineStep3.AutoSize = true;
            this.lblOnlineStep3.Location = new System.Drawing.Point(330, 43);
            this.lblOnlineStep3.Name = "lblOnlineStep3";
            this.lblOnlineStep3.Size = new System.Drawing.Size(10, 13);
            this.lblOnlineStep3.TabIndex = 12;
            this.lblOnlineStep3.Text = ".";
            this.lblOnlineStep3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOnlineStep2
            // 
            this.lblOnlineStep2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOnlineStep2.AutoSize = true;
            this.lblOnlineStep2.Location = new System.Drawing.Point(330, 23);
            this.lblOnlineStep2.Name = "lblOnlineStep2";
            this.lblOnlineStep2.Size = new System.Drawing.Size(10, 13);
            this.lblOnlineStep2.TabIndex = 11;
            this.lblOnlineStep2.Text = ".";
            this.lblOnlineStep2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOnlineStep1
            // 
            this.lblOnlineStep1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOnlineStep1.AutoSize = true;
            this.lblOnlineStep1.Location = new System.Drawing.Point(330, 3);
            this.lblOnlineStep1.Name = "lblOnlineStep1";
            this.lblOnlineStep1.Size = new System.Drawing.Size(10, 13);
            this.lblOnlineStep1.TabIndex = 10;
            this.lblOnlineStep1.Text = ".";
            this.lblOnlineStep1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Fetching categories";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Location = new System.Drawing.Point(3, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fetching mods";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.Location = new System.Drawing.Point(3, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Fetching thumbnails";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pgOnlineStep1
            // 
            this.pgOnlineStep1.Location = new System.Drawing.Point(156, 3);
            this.pgOnlineStep1.Name = "pgOnlineStep1";
            this.pgOnlineStep1.Size = new System.Drawing.Size(168, 14);
            this.pgOnlineStep1.TabIndex = 7;
            // 
            // pgOnlineStep2
            // 
            this.pgOnlineStep2.Location = new System.Drawing.Point(156, 23);
            this.pgOnlineStep2.Name = "pgOnlineStep2";
            this.pgOnlineStep2.Size = new System.Drawing.Size(168, 14);
            this.pgOnlineStep2.TabIndex = 8;
            // 
            // pgOnlineStep3
            // 
            this.pgOnlineStep3.Location = new System.Drawing.Point(156, 43);
            this.pgOnlineStep3.Name = "pgOnlineStep3";
            this.pgOnlineStep3.Size = new System.Drawing.Size(168, 14);
            this.pgOnlineStep3.TabIndex = 9;
            // 
            // pgOnlineStep5
            // 
            this.pgOnlineStep5.Location = new System.Drawing.Point(156, 83);
            this.pgOnlineStep5.Name = "pgOnlineStep5";
            this.pgOnlineStep5.Size = new System.Drawing.Size(168, 14);
            this.pgOnlineStep5.TabIndex = 17;
            // 
            // lblOnlineStep5
            // 
            this.lblOnlineStep5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOnlineStep5.AutoSize = true;
            this.lblOnlineStep5.Location = new System.Drawing.Point(330, 83);
            this.lblOnlineStep5.Name = "lblOnlineStep5";
            this.lblOnlineStep5.Size = new System.Drawing.Size(10, 13);
            this.lblOnlineStep5.TabIndex = 18;
            this.lblOnlineStep5.Text = ".";
            this.lblOnlineStep5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgOnlineStep4
            // 
            this.pgOnlineStep4.Location = new System.Drawing.Point(156, 63);
            this.pgOnlineStep4.Name = "pgOnlineStep4";
            this.pgOnlineStep4.Size = new System.Drawing.Size(168, 14);
            this.pgOnlineStep4.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.Location = new System.Drawing.Point(3, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Preparing UI";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.Location = new System.Drawing.Point(3, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Preloading thumbnails";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOnlineStep4
            // 
            this.lblOnlineStep4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOnlineStep4.AutoSize = true;
            this.lblOnlineStep4.Location = new System.Drawing.Point(330, 63);
            this.lblOnlineStep4.Name = "lblOnlineStep4";
            this.lblOnlineStep4.Size = new System.Drawing.Size(10, 13);
            this.lblOnlineStep4.TabIndex = 15;
            this.lblOnlineStep4.Text = ".";
            this.lblOnlineStep4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabOnlineUI
            // 
            this.tabOnlineUI.Controls.Add(this.splitContainer1);
            this.tabOnlineUI.Location = new System.Drawing.Point(4, 22);
            this.tabOnlineUI.Name = "tabOnlineUI";
            this.tabOnlineUI.Size = new System.Drawing.Size(927, 585);
            this.tabOnlineUI.TabIndex = 4;
            this.tabOnlineUI.Text = "__Online mods";
            this.tabOnlineUI.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerOnlineFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(927, 585);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainerOnlineFilter
            // 
            this.splitContainerOnlineFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOnlineFilter.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOnlineFilter.Name = "splitContainerOnlineFilter";
            this.splitContainerOnlineFilter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOnlineFilter.Panel1
            // 
            this.splitContainerOnlineFilter.Panel1.Controls.Add(this.flowLayoutPanel2);
            // 
            // splitContainerOnlineFilter.Panel2
            // 
            this.splitContainerOnlineFilter.Panel2.Controls.Add(this.lstOnlineMods);
            this.splitContainerOnlineFilter.Size = new System.Drawing.Size(927, 323);
            this.splitContainerOnlineFilter.SplitterDistance = 25;
            this.splitContainerOnlineFilter.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblOnlineAdvancedFilter);
            this.flowLayoutPanel2.Controls.Add(this.txtOnlineModsSearch);
            this.flowLayoutPanel2.Controls.Add(this.cbOnlineModsFilterMatchingVersion);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(927, 25);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // lblOnlineAdvancedFilter
            // 
            this.lblOnlineAdvancedFilter.AutoSize = true;
            this.lblOnlineAdvancedFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOnlineAdvancedFilter.Enabled = false;
            this.lblOnlineAdvancedFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnlineAdvancedFilter.ForeColor = System.Drawing.Color.SlateGray;
            this.lblOnlineAdvancedFilter.Location = new System.Drawing.Point(753, 7);
            this.lblOnlineAdvancedFilter.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblOnlineAdvancedFilter.Name = "lblOnlineAdvancedFilter";
            this.lblOnlineAdvancedFilter.Size = new System.Drawing.Size(171, 13);
            this.lblOnlineAdvancedFilter.TabIndex = 5;
            this.lblOnlineAdvancedFilter.Text = "Show advanced (not implemented)";
            this.lblOnlineAdvancedFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOnlineAdvancedFilter.Click += new System.EventHandler(this.lblOnlineAdvancedFilter_Click);
            // 
            // txtOnlineModsSearch
            // 
            this.txtOnlineModsSearch.Location = new System.Drawing.Point(647, 3);
            this.txtOnlineModsSearch.Name = "txtOnlineModsSearch";
            this.txtOnlineModsSearch.Size = new System.Drawing.Size(100, 20);
            this.txtOnlineModsSearch.TabIndex = 3;
            this.txtOnlineModsSearch.TextChanged += new System.EventHandler(this.txtOnlineSearch_TextChanged);
            this.txtOnlineModsSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOnlineSearch_TextChanged);
            // 
            // cbOnlineModsFilterMatchingVersion
            // 
            this.cbOnlineModsFilterMatchingVersion.AutoSize = true;
            this.cbOnlineModsFilterMatchingVersion.Location = new System.Drawing.Point(482, 3);
            this.cbOnlineModsFilterMatchingVersion.Name = "cbOnlineModsFilterMatchingVersion";
            this.cbOnlineModsFilterMatchingVersion.Size = new System.Drawing.Size(159, 17);
            this.cbOnlineModsFilterMatchingVersion.TabIndex = 6;
            this.cbOnlineModsFilterMatchingVersion.Text = "Only matching game version";
            this.cbOnlineModsFilterMatchingVersion.UseVisualStyleBackColor = true;
            this.cbOnlineModsFilterMatchingVersion.CheckedChanged += new System.EventHandler(this.cbOnlineMatchingVersion_CheckedChanged);
            // 
            // lstOnlineMods
            // 
            this.lstOnlineMods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader7});
            this.lstOnlineMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOnlineMods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lstOnlineMods.Location = new System.Drawing.Point(0, 0);
            this.lstOnlineMods.Name = "lstOnlineMods";
            this.lstOnlineMods.Size = new System.Drawing.Size(927, 294);
            this.lstOnlineMods.TabIndex = 3;
            this.lstOnlineMods.UseCompatibleStateImageBehavior = false;
            this.lstOnlineMods.View = System.Windows.Forms.View.Details;
            this.lstOnlineMods.SelectedIndexChanged += new System.EventHandler(this.lstOnlineMods_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 122;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Version";
            this.columnHeader8.Width = 47;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Title";
            this.columnHeader7.Width = 676;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label22);
            this.splitContainer3.Panel1.Controls.Add(this.ddOnlineModsReleaseVersions);
            this.splitContainer3.Panel1.Controls.Add(this.lblOnlineModsGameVersions);
            this.splitContainer3.Panel1.Controls.Add(this.label21);
            this.splitContainer3.Panel1.Controls.Add(this.label17);
            this.splitContainer3.Panel1.Controls.Add(this.pbOnlineModsThumbnail);
            this.splitContainer3.Panel1.Controls.Add(this.label18);
            this.splitContainer3.Panel1.Controls.Add(this.lblOnlineModsCategories);
            this.splitContainer3.Panel1.Controls.Add(this.lblOnlineModsAuthorWeb);
            this.splitContainer3.Panel1.Controls.Add(this.lblOnlineModsAuthor);
            this.splitContainer3.Panel1.Controls.Add(this.label16);
            this.splitContainer3.Panel1.Controls.Add(this.label15);
            this.splitContainer3.Panel1.Controls.Add(this.lblOnlineModsOpenModPage);
            this.splitContainer3.Panel1.Controls.Add(this.lblOnlineModsDescription);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.flowLayoutPanel3);
            this.splitContainer3.Panel2.Controls.Add(this.btnOnlineDownloadAsZip);
            this.splitContainer3.Size = new System.Drawing.Size(927, 258);
            this.splitContainer3.SplitterDistance = 223;
            this.splitContainer3.TabIndex = 12;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 203);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Release:";
            // 
            // ddOnlineModsReleaseVersions
            // 
            this.ddOnlineModsReleaseVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddOnlineModsReleaseVersions.FormattingEnabled = true;
            this.ddOnlineModsReleaseVersions.Location = new System.Drawing.Point(55, 200);
            this.ddOnlineModsReleaseVersions.Name = "ddOnlineModsReleaseVersions";
            this.ddOnlineModsReleaseVersions.Size = new System.Drawing.Size(121, 21);
            this.ddOnlineModsReleaseVersions.TabIndex = 25;
            this.ddOnlineModsReleaseVersions.SelectedIndexChanged += new System.EventHandler(this.ddOnlineModsReleaseVersions_SelectedIndexChanged);
            // 
            // lblOnlineModsGameVersions
            // 
            this.lblOnlineModsGameVersions.AutoSize = true;
            this.lblOnlineModsGameVersions.Location = new System.Drawing.Point(8, 142);
            this.lblOnlineModsGameVersions.Name = "lblOnlineModsGameVersions";
            this.lblOnlineModsGameVersions.Size = new System.Drawing.Size(12, 13);
            this.lblOnlineModsGameVersions.TabIndex = 24;
            this.lblOnlineModsGameVersions.Text = "x";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 127);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(133, 13);
            this.label21.TabIndex = 23;
            this.label21.Text = "Compatible game versions:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Description: ";
            // 
            // pbOnlineModsThumbnail
            // 
            this.pbOnlineModsThumbnail.Location = new System.Drawing.Point(774, 0);
            this.pbOnlineModsThumbnail.Name = "pbOnlineModsThumbnail";
            this.pbOnlineModsThumbnail.Size = new System.Drawing.Size(150, 150);
            this.pbOnlineModsThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOnlineModsThumbnail.TabIndex = 21;
            this.pbOnlineModsThumbnail.TabStop = false;
            this.pbOnlineModsThumbnail.Click += new System.EventHandler(this.pbOnlineModsThumbnail_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 157);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Categories:";
            // 
            // lblOnlineModsCategories
            // 
            this.lblOnlineModsCategories.AutoSize = true;
            this.lblOnlineModsCategories.Location = new System.Drawing.Point(8, 172);
            this.lblOnlineModsCategories.Name = "lblOnlineModsCategories";
            this.lblOnlineModsCategories.Size = new System.Drawing.Size(12, 13);
            this.lblOnlineModsCategories.TabIndex = 19;
            this.lblOnlineModsCategories.Text = "x";
            // 
            // lblOnlineModsAuthorWeb
            // 
            this.lblOnlineModsAuthorWeb.Location = new System.Drawing.Point(468, 53);
            this.lblOnlineModsAuthorWeb.Name = "lblOnlineModsAuthorWeb";
            this.lblOnlineModsAuthorWeb.Size = new System.Drawing.Size(300, 13);
            this.lblOnlineModsAuthorWeb.TabIndex = 16;
            this.lblOnlineModsAuthorWeb.TabStop = true;
            this.lblOnlineModsAuthorWeb.Text = "x";
            this.lblOnlineModsAuthorWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AnyLinkLabel_LinkClicked);
            // 
            // lblOnlineModsAuthor
            // 
            this.lblOnlineModsAuthor.Location = new System.Drawing.Point(468, 19);
            this.lblOnlineModsAuthor.Name = "lblOnlineModsAuthor";
            this.lblOnlineModsAuthor.Size = new System.Drawing.Size(300, 13);
            this.lblOnlineModsAuthor.TabIndex = 15;
            this.lblOnlineModsAuthor.TabStop = true;
            this.lblOnlineModsAuthor.Text = "x";
            this.lblOnlineModsAuthor.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblOnlineModsAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AnyLinkLabel_LinkClicked);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(465, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Author-Web:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(465, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Author:";
            // 
            // lblOnlineModsOpenModPage
            // 
            this.lblOnlineModsOpenModPage.AutoSize = true;
            this.lblOnlineModsOpenModPage.Location = new System.Drawing.Point(465, 73);
            this.lblOnlineModsOpenModPage.Name = "lblOnlineModsOpenModPage";
            this.lblOnlineModsOpenModPage.Size = new System.Drawing.Size(134, 13);
            this.lblOnlineModsOpenModPage.TabIndex = 7;
            this.lblOnlineModsOpenModPage.TabStop = true;
            this.lblOnlineModsOpenModPage.Text = "Open on factoriomods.com";
            this.lblOnlineModsOpenModPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AnyLinkLabel_LinkClicked);
            // 
            // lblOnlineModsDescription
            // 
            this.lblOnlineModsDescription.Location = new System.Drawing.Point(8, 19);
            this.lblOnlineModsDescription.Name = "lblOnlineModsDescription";
            this.lblOnlineModsDescription.Size = new System.Drawing.Size(412, 100);
            this.lblOnlineModsDescription.TabIndex = 6;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnOnlineModsDownloadAsZip);
            this.flowLayoutPanel3.Controls.Add(this.btnOnlineModsInstallUpdate);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(927, 31);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // btnOnlineModsDownloadAsZip
            // 
            this.btnOnlineModsDownloadAsZip.AutoSize = true;
            this.btnOnlineModsDownloadAsZip.Location = new System.Drawing.Point(3, 3);
            this.btnOnlineModsDownloadAsZip.Name = "btnOnlineModsDownloadAsZip";
            this.btnOnlineModsDownloadAsZip.Size = new System.Drawing.Size(102, 23);
            this.btnOnlineModsDownloadAsZip.TabIndex = 4;
            this.btnOnlineModsDownloadAsZip.Text = "Download as ZIP";
            this.btnOnlineModsDownloadAsZip.UseVisualStyleBackColor = true;
            this.btnOnlineModsDownloadAsZip.Click += new System.EventHandler(this.btnOnlineModsDownloadAsZip_Click);
            // 
            // btnOnlineModsInstallUpdate
            // 
            this.btnOnlineModsInstallUpdate.AutoSize = true;
            this.btnOnlineModsInstallUpdate.Location = new System.Drawing.Point(111, 3);
            this.btnOnlineModsInstallUpdate.Name = "btnOnlineModsInstallUpdate";
            this.btnOnlineModsInstallUpdate.Size = new System.Drawing.Size(129, 23);
            this.btnOnlineModsInstallUpdate.TabIndex = 2;
            this.btnOnlineModsInstallUpdate.Text = "Install/Reinstall/Update";
            this.btnOnlineModsInstallUpdate.UseVisualStyleBackColor = true;
            this.btnOnlineModsInstallUpdate.Click += new System.EventHandler(this.btnOnlineModsInstallUpdate_Click);
            // 
            // btnOnlineDownloadAsZip
            // 
            this.btnOnlineDownloadAsZip.Location = new System.Drawing.Point(-34, 32);
            this.btnOnlineDownloadAsZip.Name = "btnOnlineDownloadAsZip";
            this.btnOnlineDownloadAsZip.Size = new System.Drawing.Size(164, 36);
            this.btnOnlineDownloadAsZip.TabIndex = 1;
            this.btnOnlineDownloadAsZip.Text = "Download as ZIP";
            this.btnOnlineDownloadAsZip.UseVisualStyleBackColor = true;
            // 
            // tabServerSync
            // 
            this.tabServerSync.Controls.Add(this.splitContainerServerFinder);
            this.tabServerSync.Location = new System.Drawing.Point(4, 22);
            this.tabServerSync.Margin = new System.Windows.Forms.Padding(2);
            this.tabServerSync.Name = "tabServerSync";
            this.tabServerSync.Size = new System.Drawing.Size(927, 585);
            this.tabServerSync.TabIndex = 5;
            this.tabServerSync.Text = "Server sync";
            this.tabServerSync.UseVisualStyleBackColor = true;
            // 
            // splitContainerServerFinder
            // 
            this.splitContainerServerFinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerServerFinder.IsSplitterFixed = true;
            this.splitContainerServerFinder.Location = new System.Drawing.Point(0, 0);
            this.splitContainerServerFinder.Name = "splitContainerServerFinder";
            this.splitContainerServerFinder.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerServerFinder.Panel1
            // 
            this.splitContainerServerFinder.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerServerFinder.Panel1.Controls.Add(this.label10);
            this.splitContainerServerFinder.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitContainerServerFinder.Panel2
            // 
            this.splitContainerServerFinder.Panel2.Controls.Add(this.splitContainerSubServerSync);
            this.splitContainerServerFinder.Size = new System.Drawing.Size(927, 585);
            this.splitContainerServerFinder.SplitterDistance = 75;
            this.splitContainerServerFinder.SplitterWidth = 5;
            this.splitContainerServerFinder.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(20, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(754, 46);
            this.label10.TabIndex = 7;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // splitContainerSubServerSync
            // 
            this.splitContainerSubServerSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSubServerSync.IsSplitterFixed = true;
            this.splitContainerSubServerSync.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSubServerSync.Name = "splitContainerSubServerSync";
            this.splitContainerSubServerSync.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSubServerSync.Panel1
            // 
            this.splitContainerSubServerSync.Panel1.Controls.Add(this.btnServerSyncSyncToLocal);
            this.splitContainerSubServerSync.Panel1.Controls.Add(this.btnServerSyncConnect);
            this.splitContainerSubServerSync.Panel1.Controls.Add(this.lblServerSyncState);
            this.splitContainerSubServerSync.Panel1.Controls.Add(this.label14);
            this.splitContainerSubServerSync.Panel1.Controls.Add(this.txtServerSyncPort);
            this.splitContainerSubServerSync.Panel1.Controls.Add(this.label12);
            this.splitContainerSubServerSync.Panel1.Controls.Add(this.txtServerSyncHost);
            // 
            // splitContainerSubServerSync.Panel2
            // 
            this.splitContainerSubServerSync.Panel2.Controls.Add(this.lstServerSyncMods);
            this.splitContainerSubServerSync.Size = new System.Drawing.Size(927, 505);
            this.splitContainerSubServerSync.SplitterDistance = 74;
            this.splitContainerSubServerSync.SplitterWidth = 1;
            this.splitContainerSubServerSync.TabIndex = 6;
            // 
            // btnServerSyncSyncToLocal
            // 
            this.btnServerSyncSyncToLocal.Enabled = false;
            this.btnServerSyncSyncToLocal.Location = new System.Drawing.Point(677, 26);
            this.btnServerSyncSyncToLocal.Name = "btnServerSyncSyncToLocal";
            this.btnServerSyncSyncToLocal.Size = new System.Drawing.Size(118, 20);
            this.btnServerSyncSyncToLocal.TabIndex = 10;
            this.btnServerSyncSyncToLocal.Text = "Sync all to local";
            this.btnServerSyncSyncToLocal.UseVisualStyleBackColor = true;
            this.btnServerSyncSyncToLocal.Click += new System.EventHandler(this.btnServerSyncSyncToLocal_Click);
            // 
            // btnServerSyncConnect
            // 
            this.btnServerSyncConnect.Enabled = false;
            this.btnServerSyncConnect.Location = new System.Drawing.Point(277, 26);
            this.btnServerSyncConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnServerSyncConnect.Name = "btnServerSyncConnect";
            this.btnServerSyncConnect.Size = new System.Drawing.Size(111, 20);
            this.btnServerSyncConnect.TabIndex = 9;
            this.btnServerSyncConnect.Text = "Connect";
            this.btnServerSyncConnect.UseVisualStyleBackColor = true;
            this.btnServerSyncConnect.Click += new System.EventHandler(this.btnServerSyncConnect_Click);
            // 
            // lblServerSyncState
            // 
            this.lblServerSyncState.AutoSize = true;
            this.lblServerSyncState.Location = new System.Drawing.Point(392, 29);
            this.lblServerSyncState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServerSyncState.Name = "lblServerSyncState";
            this.lblServerSyncState.Size = new System.Drawing.Size(74, 13);
            this.lblServerSyncState.TabIndex = 5;
            this.lblServerSyncState.Text = "Not requested";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(196, 11);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Port:";
            // 
            // txtServerSyncPort
            // 
            this.txtServerSyncPort.Location = new System.Drawing.Point(199, 26);
            this.txtServerSyncPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtServerSyncPort.Name = "txtServerSyncPort";
            this.txtServerSyncPort.Size = new System.Drawing.Size(68, 20);
            this.txtServerSyncPort.TabIndex = 7;
            this.txtServerSyncPort.Text = "34197";
            this.txtServerSyncPort.Click += new System.EventHandler(this.CheckServerSyncButtonState);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Hostname/IP:";
            // 
            // txtServerSyncHost
            // 
            this.txtServerSyncHost.Location = new System.Drawing.Point(8, 26);
            this.txtServerSyncHost.Margin = new System.Windows.Forms.Padding(2);
            this.txtServerSyncHost.Name = "txtServerSyncHost";
            this.txtServerSyncHost.Size = new System.Drawing.Size(179, 20);
            this.txtServerSyncHost.TabIndex = 5;
            this.txtServerSyncHost.Click += new System.EventHandler(this.CheckServerSyncButtonState);
            // 
            // lstServerSyncMods
            // 
            this.lstServerSyncMods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.lstServerSyncMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstServerSyncMods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstServerSyncMods.FullRowSelect = true;
            this.lstServerSyncMods.GridLines = true;
            this.lstServerSyncMods.Location = new System.Drawing.Point(0, 0);
            this.lstServerSyncMods.Name = "lstServerSyncMods";
            this.lstServerSyncMods.Size = new System.Drawing.Size(927, 430);
            this.lstServerSyncMods.TabIndex = 3;
            this.lstServerSyncMods.UseCompatibleStateImageBehavior = false;
            this.lstServerSyncMods.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Name";
            this.columnHeader12.Width = 178;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Remote";
            this.columnHeader13.Width = 78;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Local";
            this.columnHeader14.Width = 120;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Actions";
            this.columnHeader15.Width = 217;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.cbSkipThumbnails);
            this.tabSettings.Controls.Add(this.btnSettingsBackup);
            this.tabSettings.Controls.Add(this.txtPathBackup);
            this.tabSettings.Controls.Add(this.label20);
            this.tabSettings.Controls.Add(this.cbEnableExperimental);
            this.tabSettings.Controls.Add(this.btnSettingsCache);
            this.tabSettings.Controls.Add(this.txtPathCache);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.btnSettingsTemp);
            this.tabSettings.Controls.Add(this.txtPathTemp);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.btnSettingsAutodetect);
            this.tabSettings.Controls.Add(this.btnSettingsModPath);
            this.tabSettings.Controls.Add(this.txtSettingsModPath);
            this.tabSettings.Controls.Add(this.label3);
            this.tabSettings.Controls.Add(this.lblSettingsExeVersion);
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Controls.Add(this.btnSettingsSave);
            this.tabSettings.Controls.Add(this.btnSettingsFactorieExePath);
            this.tabSettings.Controls.Add(this.txtSettingsPathExecuteable);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(927, 585);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // cbSkipThumbnails
            // 
            this.cbSkipThumbnails.AutoSize = true;
            this.cbSkipThumbnails.Location = new System.Drawing.Point(29, 290);
            this.cbSkipThumbnails.Name = "cbSkipThumbnails";
            this.cbSkipThumbnails.Size = new System.Drawing.Size(208, 17);
            this.cbSkipThumbnails.TabIndex = 22;
            this.cbSkipThumbnails.Text = "[Online mods] Skip image downloading";
            this.cbSkipThumbnails.UseVisualStyleBackColor = true;
            this.cbSkipThumbnails.Visible = false;
            // 
            // btnSettingsBackup
            // 
            this.btnSettingsBackup.Location = new System.Drawing.Point(551, 244);
            this.btnSettingsBackup.Name = "btnSettingsBackup";
            this.btnSettingsBackup.Size = new System.Drawing.Size(32, 23);
            this.btnSettingsBackup.TabIndex = 21;
            this.btnSettingsBackup.Text = "....";
            this.btnSettingsBackup.UseVisualStyleBackColor = true;
            // 
            // txtPathBackup
            // 
            this.txtPathBackup.Location = new System.Drawing.Point(39, 246);
            this.txtPathBackup.Name = "txtPathBackup";
            this.txtPathBackup.Size = new System.Drawing.Size(506, 20);
            this.txtPathBackup.TabIndex = 20;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 230);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Backup storage:";
            // 
            // cbEnableExperimental
            // 
            this.cbEnableExperimental.AutoSize = true;
            this.cbEnableExperimental.Location = new System.Drawing.Point(11, 271);
            this.cbEnableExperimental.Margin = new System.Windows.Forms.Padding(2);
            this.cbEnableExperimental.Name = "cbEnableExperimental";
            this.cbEnableExperimental.Size = new System.Drawing.Size(162, 17);
            this.cbEnableExperimental.TabIndex = 18;
            this.cbEnableExperimental.Tag = "blockevent";
            this.cbEnableExperimental.Text = "Enable experimental features";
            this.cbEnableExperimental.UseVisualStyleBackColor = true;
            this.cbEnableExperimental.CheckedChanged += new System.EventHandler(this.cbEnableExperimental_CheckedChanged);
            // 
            // btnSettingsCache
            // 
            this.btnSettingsCache.Location = new System.Drawing.Point(551, 202);
            this.btnSettingsCache.Name = "btnSettingsCache";
            this.btnSettingsCache.Size = new System.Drawing.Size(32, 23);
            this.btnSettingsCache.TabIndex = 16;
            this.btnSettingsCache.Text = "....";
            this.btnSettingsCache.UseVisualStyleBackColor = true;
            this.btnSettingsCache.Click += new System.EventHandler(this.btnSettingsCache_Click);
            // 
            // txtPathCache
            // 
            this.txtPathCache.Location = new System.Drawing.Point(39, 204);
            this.txtPathCache.Name = "txtPathCache";
            this.txtPathCache.Size = new System.Drawing.Size(506, 20);
            this.txtPathCache.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cache folder (fastens information getting, e.g. thumbnails):";
            // 
            // btnSettingsTemp
            // 
            this.btnSettingsTemp.Location = new System.Drawing.Point(551, 155);
            this.btnSettingsTemp.Name = "btnSettingsTemp";
            this.btnSettingsTemp.Size = new System.Drawing.Size(32, 23);
            this.btnSettingsTemp.TabIndex = 13;
            this.btnSettingsTemp.Text = "....";
            this.btnSettingsTemp.UseVisualStyleBackColor = true;
            this.btnSettingsTemp.Click += new System.EventHandler(this.btnSettingsTemp_Click);
            // 
            // txtPathTemp
            // 
            this.txtPathTemp.Location = new System.Drawing.Point(39, 157);
            this.txtPathTemp.Name = "txtPathTemp";
            this.txtPathTemp.Size = new System.Drawing.Size(506, 20);
            this.txtPathTemp.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Temporary download folder:";
            // 
            // btnSettingsAutodetect
            // 
            this.btnSettingsAutodetect.Location = new System.Drawing.Point(11, 10);
            this.btnSettingsAutodetect.Name = "btnSettingsAutodetect";
            this.btnSettingsAutodetect.Size = new System.Drawing.Size(163, 23);
            this.btnSettingsAutodetect.TabIndex = 10;
            this.btnSettingsAutodetect.Text = "Try auto detect settings";
            this.btnSettingsAutodetect.UseVisualStyleBackColor = true;
            this.btnSettingsAutodetect.Click += new System.EventHandler(this.btnModsPathAutodetect_Click);
            // 
            // btnSettingsModPath
            // 
            this.btnSettingsModPath.Location = new System.Drawing.Point(551, 109);
            this.btnSettingsModPath.Name = "btnSettingsModPath";
            this.btnSettingsModPath.Size = new System.Drawing.Size(32, 23);
            this.btnSettingsModPath.TabIndex = 8;
            this.btnSettingsModPath.Text = "....";
            this.btnSettingsModPath.UseVisualStyleBackColor = true;
            this.btnSettingsModPath.Click += new System.EventHandler(this.btnSettingsMods_Click);
            // 
            // txtSettingsModPath
            // 
            this.txtSettingsModPath.Location = new System.Drawing.Point(39, 111);
            this.txtSettingsModPath.Name = "txtSettingsModPath";
            this.txtSettingsModPath.Size = new System.Drawing.Size(506, 20);
            this.txtSettingsModPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mods folder path:";
            // 
            // lblSettingsExeVersion
            // 
            this.lblSettingsExeVersion.AutoSize = true;
            this.lblSettingsExeVersion.Location = new System.Drawing.Point(179, 83);
            this.lblSettingsExeVersion.Name = "lblSettingsExeVersion";
            this.lblSettingsExeVersion.Size = new System.Drawing.Size(27, 13);
            this.lblSettingsExeVersion.TabIndex = 5;
            this.lblSettingsExeVersion.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Found version:";
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Location = new System.Drawing.Point(11, 313);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(143, 23);
            this.btnSettingsSave.TabIndex = 3;
            this.btnSettingsSave.Text = "check && save";
            this.btnSettingsSave.UseVisualStyleBackColor = true;
            this.btnSettingsSave.Click += new System.EventHandler(this.btnSettingsSave_Click);
            // 
            // btnSettingsFactorieExePath
            // 
            this.btnSettingsFactorieExePath.Location = new System.Drawing.Point(551, 60);
            this.btnSettingsFactorieExePath.Name = "btnSettingsFactorieExePath";
            this.btnSettingsFactorieExePath.Size = new System.Drawing.Size(32, 23);
            this.btnSettingsFactorieExePath.TabIndex = 2;
            this.btnSettingsFactorieExePath.Text = "....";
            this.btnSettingsFactorieExePath.UseVisualStyleBackColor = true;
            this.btnSettingsFactorieExePath.Click += new System.EventHandler(this.BtnSettingsExecuteable);
            // 
            // txtSettingsPathExecuteable
            // 
            this.txtSettingsPathExecuteable.Location = new System.Drawing.Point(39, 62);
            this.txtSettingsPathExecuteable.Name = "txtSettingsPathExecuteable";
            this.txtSettingsPathExecuteable.Size = new System.Drawing.Size(506, 20);
            this.txtSettingsPathExecuteable.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Executable path:";
            // 
            // openfileSettingsExecuteable
            // 
            this.openfileSettingsExecuteable.FileName = "Factorio.exe";
            this.openfileSettingsExecuteable.Filter = "Factorio.exe|Factorio.exe";
            this.openfileSettingsExecuteable.ReadOnlyChecked = true;
            this.openfileSettingsExecuteable.RestoreDirectory = true;
            this.openfileSettingsExecuteable.SupportMultiDottedExtensions = true;
            // 
            // openfolderSettingsModPath
            // 
            this.openfolderSettingsModPath.ShowNewFolderButton = false;
            // 
            // openfileLocalModsRestore
            // 
            this.openfileLocalModsRestore.Filter = "Zipped ModBackup|*.zip";
            // 
            // ManagerUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 611);
            this.Controls.Add(this.tabControl);
            this.Name = "ManagerUi";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManagerUI_FormClosing);
            this.Load += new System.EventHandler(this.ManagerUI_Load);
            this.Resize += new System.EventHandler(this.ManagerUI_Resize);
            this.tabControl.ResumeLayout(false);
            this.tabPending.ResumeLayout(false);
            this.tabPending.PerformLayout();
            this.tabLocalMods.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panelLocalModsBackupRestoreProgress.ResumeLayout(false);
            this.panelLocalModsBackupRestoreProgress.PerformLayout();
            this.flowpanelLocalMods.ResumeLayout(false);
            this.tabOnlineMods.ResumeLayout(false);
            this.splitContainerOnlineMods.Panel1.ResumeLayout(false);
            this.splitContainerOnlineMods.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOnlineMods)).EndInit();
            this.splitContainerOnlineMods.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabOnlineUI.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerOnlineFilter.Panel1.ResumeLayout(false);
            this.splitContainerOnlineFilter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOnlineFilter)).EndInit();
            this.splitContainerOnlineFilter.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOnlineModsThumbnail)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tabServerSync.ResumeLayout(false);
            this.splitContainerServerFinder.Panel1.ResumeLayout(false);
            this.splitContainerServerFinder.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerServerFinder)).EndInit();
            this.splitContainerServerFinder.ResumeLayout(false);
            this.splitContainerSubServerSync.Panel1.ResumeLayout(false);
            this.splitContainerSubServerSync.Panel1.PerformLayout();
            this.splitContainerSubServerSync.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSubServerSync)).EndInit();
            this.splitContainerSubServerSync.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPending;
        private System.Windows.Forms.TabPage tabLocalMods;
        private System.Windows.Forms.TabPage tabOnlineMods;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.Button btnSettingsFactorieExePath;
        private System.Windows.Forms.TextBox txtSettingsPathExecuteable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openfileSettingsExecuteable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSettingsExeVersion;
        private System.Windows.Forms.Button btnSettingsModPath;
        private System.Windows.Forms.TextBox txtSettingsModPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog openfolderSettingsModPath;
        private System.Windows.Forms.Button btnSettingsAutodetect;
        private System.Windows.Forms.Button btnSettingsCache;
        private System.Windows.Forms.TextBox txtPathCache;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSettingsTemp;
        private System.Windows.Forms.TextBox txtPathTemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog openfolderTemp;
        private System.Windows.Forms.FolderBrowserDialog openfolderCache;
        private System.Windows.Forms.SplitContainer splitContainerOnlineMods;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOnlineModeEnable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar pgOnlineStep1;
        private System.Windows.Forms.ProgressBar pgOnlineStep2;
        private System.Windows.Forms.ProgressBar pgOnlineStep3;
        private System.Windows.Forms.Label lblOnlineStep1;
        private System.Windows.Forms.Label lblOnlineStep3;
        private System.Windows.Forms.Label lblOnlineStep2;
        private System.Windows.Forms.ProgressBar pgOnlineStep5;
        private System.Windows.Forms.Label lblOnlineStep5;
        private System.Windows.Forms.ProgressBar pgOnlineStep4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblOnlineStep4;
        private System.Windows.Forms.TabPage tabOnlineUI;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ListViewEx lstPendingChanges;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TabPage tabServerSync;
        private System.Windows.Forms.SplitContainer splitContainerServerFinder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbEnableExperimental;
        private System.Windows.Forms.Label lblServerSyncState;
        private System.Windows.Forms.SplitContainer splitContainerSubServerSync;
        private System.Windows.Forms.Button btnServerSyncConnect;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtServerSyncPort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtServerSyncHost;
        private ListViewEx lstServerSyncMods;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ListViewEx lstLocalMods;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.FlowLayoutPanel flowpanelLocalMods;
        private System.Windows.Forms.Button btnLocalModsReload;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Button btnServerSyncSyncToLocal;
        private System.Windows.Forms.Button btnLocalModsBackup;
        private System.Windows.Forms.OpenFileDialog openfileLocalModsRestore;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PictureBox pbOnlineModsThumbnail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblOnlineModsCategories;
        private System.Windows.Forms.LinkLabel lblOnlineModsAuthorWeb;
        private System.Windows.Forms.LinkLabel lblOnlineModsAuthor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.LinkLabel lblOnlineModsOpenModPage;
        private System.Windows.Forms.Label lblOnlineModsDescription;
        private System.Windows.Forms.Button btnOnlineDownloadAsZip;
        private System.Windows.Forms.SplitContainer splitContainerOnlineFilter;
        private ListViewEx lstOnlineMods;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblOnlineAdvancedFilter;
        private System.Windows.Forms.TextBox txtOnlineModsSearch;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbOnlineModsFilterMatchingVersion;
        private System.Windows.Forms.Button btnSettingsBackup;
        private System.Windows.Forms.TextBox txtPathBackup;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panelLocalModsBackupRestoreProgress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ProgressBar pgLocalModsBackupRestoreProgress;
        private System.Windows.Forms.Label lblLocalModsBackupRestoreProgress;
        private System.Windows.Forms.Button btnLocalModsRestore;
        private System.Windows.Forms.Label lblOnlineModsGameVersions;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnOnlineModsDownloadAsZip;
        private System.Windows.Forms.Button btnOnlineModsInstallUpdate;
        private System.Windows.Forms.CheckBox cbSkipThumbnails;
        private System.Windows.Forms.ComboBox ddOnlineModsReleaseVersions;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnPendingChangesApplyAll;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
    }
}

