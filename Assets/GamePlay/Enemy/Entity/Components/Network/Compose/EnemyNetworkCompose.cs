using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.Components.Network.Common;
using GamePlay.Enemy.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Enemy.Entity.Components.Network.Properties.Runtime;
using GamePlay.Enemy.Entity.Views.Transforms.Remote.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "EnemyNetworkCompose",
        menuName = EnemyNetworkRoutes.Root + "Compose")]
    public class EnemyNetworkCompose : ScriptableObject, IComponentsCompose
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