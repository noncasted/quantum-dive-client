using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Player.Entity.Network.Common;
using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Network.Sync.Properties.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Player.Entity.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "Player_NetworkCompose",
        menuName = PlayerNetworkRoutes.Root + "Compose")]
    public class PlayerNetworkCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private EntityProviderFactory _entityProvider;
        [SerializeField] private NetworkPropertiesFactory _properties;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _entityProvider,
            _properties
        };
    }
}