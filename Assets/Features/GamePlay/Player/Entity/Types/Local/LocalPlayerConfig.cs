using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Common.Definition;
using GamePlay.Player.Entity.Components.Compose;
using GamePlay.Player.Entity.Components.Equipment.Compose;
using GamePlay.Player.Entity.Components.Network.Compose;
using GamePlay.Player.Entity.States.Compose;
using GamePlay.Player.Entity.Types.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Types.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerConfigRoutes.LocalName,
        menuName = PlayerConfigRoutes.LocalPath)]
    public class LocalPlayerConfig : ScriptableObject, ILocalPlayerConfig
    {
        [SerializeField] private LocalPlayerComponentsCompose _components;
        [SerializeField] private LocalPlayerEquipmentCompose _equipment;
        [SerializeField] private LocalPlayerStatesCompose _states;
        [SerializeField] private PlayerNetworkCompose _network;

        [SerializeField] private LocalPlayerViewFactory _prefab;

        public ScopedEntityViewFactory Prefab => _prefab;

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