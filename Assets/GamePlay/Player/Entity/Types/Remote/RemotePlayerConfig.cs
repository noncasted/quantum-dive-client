using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Common.Definition;
using GamePlay.Player.Entity.Components.Compose;
using GamePlay.Player.Entity.Components.Equipment.Compose;
using GamePlay.Player.Entity.Components.Network.Compose;
using GamePlay.Player.Entity.States.Compose;
using GamePlay.Player.Entity.Types.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Types.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerConfigRoutes.RemoteName,
        menuName = PlayerConfigRoutes.RemotePath)]
    public class RemotePlayerConfig : ScriptableObject, IRemotePlayerConfig
    {
        [SerializeField] private RemotePlayerComponentsCompose _components;
        [SerializeField] private RemotePlayerEquipmentCompose _equipment;
        [SerializeField] private RemotePlayerStatesCompose _states;
        [SerializeField] private PlayerNetworkCompose _network;
        
        [SerializeField] private RemotePlayerViewFactory _prefab;

        public PlayerViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
        };

        public IReadOnlyList<IComponentsCompose> Composes => new IComponentsCompose[]
        {
            _components,
            _equipment,
            _states,
            _network
        };
    }
}