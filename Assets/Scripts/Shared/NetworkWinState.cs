using Unity.Netcode;

namespace Shared
{
    public enum WinState
    {
        Invalid,
        Win,
        Loss
    }

    /// <summary>
    /// MonoBehaviour containing only one NetworkVariableBool to represent the game session's win state.
    /// </summary>
    public class NetworkWinState : NetworkBehaviour
    {
        public NetworkVariable<WinState> winState = new NetworkVariable<WinState>(WinState.Invalid);
    }
}
