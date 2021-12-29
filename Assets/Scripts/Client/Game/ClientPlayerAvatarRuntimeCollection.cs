using Client.Game.Character;
using Shared.Game.Entity;
using Shared.ScriptableObjects;
using UnityEngine;

namespace Client.Game
{
    /// <summary>
    /// A runtime list of <see cref="PersistentPlayer"/> objects that is populated both on clients and server.
    /// </summary>
    [CreateAssetMenu]
    public class ClientPlayerAvatarRuntimeCollection : RuntimeCollection<ClientPlayerAvatar>
    {
    }
}
