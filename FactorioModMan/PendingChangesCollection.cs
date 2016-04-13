using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using FactorioModMan.PendingActions;
using Microsoft.SqlServer.Server;

namespace FactorioModMan
{
    internal class PendingChangesCollection : List<PendingChangeBase>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private OnlineModManager _onlineManager;
        private LocalModManager _localManager;

        public void RaiseItemsEventExternal()
        {
            RaisePropertyChangedEvent("Items");
        }

        private void RaisePropertyChangedEvent(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        internal void AttachOnlineManager(OnlineModManager onlineModManager)
        {
            _onlineManager = onlineModManager;
        }

        internal void AttachLocalManager(LocalModManager localModManager)
        {
            _localManager = localModManager;
        }

        internal void AddDownload(ModInfo mod, int releaseIndex, string targetFilename)
        {
            //TODO: get filename
            Add(new PendingDownload(mod, mod.Releases[releaseIndex], targetFilename));
            RaisePropertyChangedEvent("Items");
        }

        public void AddUninstall(ModInfo mod)
        {
            Add(new PendingUninstall(mod));
        }

        internal void AddUpdate(ModInfo mod, int releaseIndex = 0)
        {
            throw new NotImplementedException();
        }

        public void StartAll()
        {
            for (int i = 0; i < this.Count; i++)
            {
                try
                {
                    this[i].Result = this[i].Run(_onlineManager, _localManager);
                    RaisePropertyChangedEvent("Items");
                }
                catch
                {
                    // ignored
                }
            }
        }

        /// <summary>
        /// Adds a pending mod INSTALL for the local file
        /// </summary>
        /// <param name="mod">mod to install</param>
        /// <param name="sourceFile">local file of mod</param>
        public void AddInstall(ModInfo mod, string sourceFile)
        {
            Add(new PendingInstall(mod, sourceFile));
            RaisePropertyChangedEvent("Items");
        }
    }
}