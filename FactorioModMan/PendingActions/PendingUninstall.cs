using System;

namespace FactorioModMan.PendingActions
{
    internal class PendingUninstall : PendingChangeBase
    {
        private ModInfo mod;


        public PendingUninstall(ModInfo mod) : base(PendingAction.Uninstall)
        {
            this.mod = mod;
        }

        public override PendingActionResult Run(OnlineModManager _onlineManager, LocalModManager _localManager)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => "Uninstall: " + mod.Name;
    }
}