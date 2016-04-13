using System;

namespace FactorioModMan.PendingActions
{
    internal class PendingInstall : PendingChangeBase
    {
        private readonly ModInfo _mod;
        private readonly string _srcfile;

        public PendingInstall(ModInfo mod, string srcfile) : base(PendingAction.Install)
        {
            _mod = mod;
            _srcfile = srcfile;
        }

        public override PendingActionResult Run(OnlineModManager _onlineManager, LocalModManager _localManager)
        {
            //_localManager.Install();
            return PendingActionResult.Completed;
            ;
            throw new NotImplementedException();
        }

        public override string ToString() => $"Install: {_mod.Name} ({_srcfile})";
    }
}