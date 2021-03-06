using Shared.ScriptableObjects;
using Unity.Netcode;
using UnityEngine;

namespace Shared.Game.State
{
    public class NetworkGameState : NetworkBehaviour
    {
        [SerializeField]
        TransformVariable m_GameStateTransformVariable;

        [SerializeField]
        NetworkWinState m_NetworkWinState;

        public NetworkWinState NetworkWinState => m_NetworkWinState;

        void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public override void OnNetworkSpawn()
        {
            gameObject.name = "NetworkGameState";

            m_GameStateTransformVariable.Value = transform;
        }

        public override void OnNetworkDespawn()
        {
            m_GameStateTransformVariable.Value = null;
        }
    }
}
