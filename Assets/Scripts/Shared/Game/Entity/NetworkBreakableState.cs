using Unity.Netcode;

namespace Shared.Game.Entity
{
    /// <summary>
    /// Shared Network logic for breakable items.
    /// </summary>
    public class NetworkBreakableState : NetworkBehaviour, ITargetable
    {
        /// <summary>
        /// Is the item broken or not?
        /// </summary>
        public NetworkVariable<bool> IsBroken;

        public bool IsNpc { get { return true;  } }

        public bool IsValidTarget {  get { return !IsBroken.Value; } }
    }

}

