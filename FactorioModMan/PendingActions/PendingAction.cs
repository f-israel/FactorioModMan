using System;

namespace FactorioModMan.PendingActions
{
    internal class PendingAction : PendingChangeBase
    {
        private string _description = null;
        public PendingAction(Func<PendingActionResult> action, string description = null) : base(PendingAction.Install)
        {
            this._description = description;
        }

        public override PendingActionResult Run(OnlineModManager _onlineManager, LocalModManager _localManager)
        {
            throw new NotImplementedException();

        }

        public override string ToString() => "Specialised action: " + (_description ?? "(no description given)");
    }
}