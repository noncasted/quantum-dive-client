using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Network.Common;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Components.Network.Properties.Runtime;
using GamePlay.Player.Entity.Components.Network.TransformSyncs.Runtime;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Network.Compose
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