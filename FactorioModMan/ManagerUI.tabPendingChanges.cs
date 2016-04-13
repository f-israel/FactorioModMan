using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FactorioModMan
{
    public partial class ManagerUi
    {
        private readonly PendingChangesCollection PendingChanges = new PendingChangesCollection();

        private void CTOR_TabPendingChanges()
        {
            PendingChanges.AttachLocalManager(_localModManager);
            PendingChanges.AttachOnlineManager(_onlineModManager);

            //pending changes event handler
            PendingChanges.PropertyChanged += PendingChanges_PropertyChanged;
            PendingChanges.RaiseItemsEventExternal(); //for initial clear and so on

            //_localModManager.Install();
        }

        private void PendingChanges_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            lstPendingChanges.Items.Clear();
            for (int i = 0; i < PendingChanges.Count; i++)
            {
                lstPendingChanges.Items.Add(new ListViewItem(new[]
                {
                    i.ToString(),
                    PendingChanges[i].Action.ToString(),
                    PendingChanges[i].ToString(),
                    PendingChanges[i].Result.ToString()
                }));

                FlowLayoutPanel flp = new FlowLayoutPanel();
                Button btn = MakeButtonCompatible(new Button());
                btn.Tag = i;
                btn.Click += (_sender, _e) =>
                {
                    if (true) //TODO: make confirm
                    {
                        int idx = (int)((Button)_sender).Tag;
                        PendingChanges.Remove(PendingChanges[idx]);
                        PendingChanges.RaiseItemsEventExternal();
                    }
                };
                flp.Controls.Add(btn);
                lstPendingChanges.AddEmbeddedControl(flp, lstPendingChanges.Columns.Count-1, lstPendingChanges.Items.Count - 1);
            }
        }

        private void lstPendingChanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bp = "";
        }
    }
}