using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Enemies.Entity.Network.Common;
using GamePlay.Enemies.Entity.Network.EntityHandler.Runtime;
using GamePlay.Enemies.Entity.Network.Properties.Runtime;
using GamePlay.Enemies.Entity.Views.Transforms.Remote.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Enemies.Entity.Network.Compose
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