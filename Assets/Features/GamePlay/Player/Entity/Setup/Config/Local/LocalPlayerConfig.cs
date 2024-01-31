using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Player.Entity.Components.Compose;
using Features.GamePlay.Player.Entity.Components.Equipment.Compose;
using Features.GamePlay.Player.Entity.Network.Compose;
using Features.GamePlay.Player.Entity.States.Compose;
using GamePlay.Player.Entity.Setup.Config.Common;
using GamePlay.Player.Entity.Setup.Root.Local;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Config.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerConfigRoutes.LocalName,
        menuName = PlayerConfigRoutes.LocalPath)]
    public class LocalPlayerConfig : ScriptableObject, IScopedEntityConfig
    {
        [SerializeField] private DefaultCallbacksComponentFactory _defaultCallbacks;
        [SerializeField] private LocalPlayerRootFactory _root;

        [SerializeField] private LocalPlayerComponentsCompose _components;
        [SerializeField] private LocalPlayerEquipmentCompose _equipment;
        [SerializeField] private LocalPlayerStatesCompose _states;
        [SerializeField] private PlayerNetworkCompose _network;
        
        [SerializeField] private LocalPlayerViewFactoryFactory _prefab;

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