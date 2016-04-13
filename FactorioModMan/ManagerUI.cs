using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FactorioModMan
{
    public partial class ManagerUi : Form
    {
        private readonly ShellExPipe _pipes = new ShellExPipe();
        private FactorioVersion _factorioVersion;


        public ManagerUi()
        {
            InitializeComponent();

            //enable named pipe catcher
            _pipes.OnData += _handleIncoming;
        }

        private void ManagerUI_Load(object sender, EventArgs e)
        {
            //be sure to keep this order as it is important!
            CTOR_TabSettings();
            CTOR_TabLocalMods();
            CTOR_TabServerSync();
            CTOR_TabOnline();

            CTOR_TabPendingChanges(); //needs to be last as it need some things from local and online



            if (!CheckSettings())
            {
                MessageBox.Show("This seems to be the first start or the configuration has errors. Please correct the settings to continue.");
                tabControl.SelectTab("tabSettings");

                _blockTabs = true;
            }
            else
            {
                RefreshLocalModList();
            }


            //TODO: REMOVE DEBUGGING
            tabControl.SelectTab("tabServerSync");
            txtServerSyncHost.Text = "factorio";
            btnServerSyncConnect_Click(null, null);
            //btnOnlineModeEnable_Click(null, null);

        }



        private void _handleIncoming(ModInfo urlhandler)
        {
            if (InvokeRequired) Invoke(new MethodInvoker(() => { _handleIncoming(urlhandler); }));
        }

        private void ManagerUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pipes.Dispose();
        }


        private Button MakeButtonCompatible(Button btn)
        {
            btn.Margin = new Padding(0);
            btn.Height = 20;
            btn.Font = new Font(btn.Font.FontFamily, 5.75f);
            return btn;
        }

        private void ManagerUI_Resize(object sender, EventArgs e)
        {
            ResizeServerSyncList();
            ResizeInstalledModList();
            ResizeOnlineModList();
        }


        private void AnyLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.LinkData != null) Process.Start(e.Link.LinkData.ToString());
        }
        

        private void btnPendingChangesApplyAll_Click(object sender, EventArgs e)
        {
            PendingChanges.StartAll();
        }
    }
}