using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Compose;
using GamePlay.Player.Entity.Components.Equipment.Compose;
using GamePlay.Player.Entity.Network.Compose;
using GamePlay.Player.Entity.Setup.Config.Common;
using GamePlay.Player.Entity.Setup.Root.Remote;
using GamePlay.Player.Entity.States.Compose;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Config.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerConfigRoutes.RemoteName,
        menuName = PlayerConfigRoutes.RemotePath)]
    public class RemotePlayerConfig : ScriptableObject, IScopedEntityConfig
    {
        [SerializeField] private DefaultCallbacksComponentFactory _defaultCallbacks;
        [SerializeField] private RemotePlayerRootFactory _root;
        
        [SerializeField] private RemotePlayerComponentsCompose _components;
        [SerializeField] private RemotePlayerEquipmentCompose _equipment;
        [SerializeField] private RemotePlayerStatesCompose _states;
        [SerializeField] private PlayerNetworkCompose _network;
        
        [SerializeField] private RemotePlayerViewFactoryFactory _prefab;

        public ScopedEntityViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _defaultCallbacks,
            _root,
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