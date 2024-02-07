using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Network.Common;
using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Network.Properties.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Remote.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "Player_NetworkCompose",
        menuName = PlayerNetworkRoutes.Root + "Compose")]
    public class PlayerNetworkCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private EntityProviderFactory _entityProvider;
        [SerializeField] private NetworkPropertiesFactory _properties;
        [SerializeField] private TransformSyncFactory _transformSync;
        
        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _entityProvider,
            _properties,
            _transformSync
        };
    }
}