using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Network.Common;
using GamePlay.Enemy.Entity.Network.EntityHandler.Runtime;
using GamePlay.Enemy.Entity.Network.Properties.Runtime;
using GamePlay.Enemy.Entity.Views.Transforms.Remote.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Network.Compose
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