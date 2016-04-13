using System;

namespace FactorioModMan.PendingActions
{
    internal abstract class PendingChangeBase
    {
        [Flags]
        public enum PendingAction : byte
        {
            None = 0,
            Download = 1 << 1,
            Install = 1 << 2,
            Uninstall = 1 << 3,
            Update = 1 << 4
        }

        public enum PendingActionResult
        {
            Pending,
            Running,
            Completed,
            Failed,
            Skipped
        }

        public PendingAction Action;
        internal PendingActionResult Result = PendingActionResult.Pending;

        protected PendingChangeBase(PendingAction action)
        {
            this.Action = action;
        }
        public abstract override string ToString();
        public abstract PendingActionResult Run(OnlineModManager _onlineManager, LocalModManager _localManager);
    }

}