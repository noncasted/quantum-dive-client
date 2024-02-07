using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Enemies.Entity.Components.Compose;
using Features.GamePlay.Enemies.Entity.Network.Compose;
using Features.GamePlay.Enemies.Entity.States.Compose;
using GamePlay.Enemies.Entity.Definition.Config;
using GamePlay.Enemies.Types.Range.States.Shoot.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Range.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRangeConfigRoutes.RemoteName,
        menuName = EnemyRangeConfigRoutes.RemotePath)]
    public class RemoteEnemyRangeConfig : ScriptableObject, IRemoteEnemyConfig
    {
        [SerializeField] private RemoteEnemyComponentsCompose _components;
        [SerializeField] private RemoteEnemyStatesCompose _states;
        [SerializeField] private EnemyNetworkCompose _network;

        [SerializeField] private RemoteShootFactory _shoot;
        
        [SerializeField] private RemoteEnemyRangeViewFactory _prefab;
        
        public ScopedEntityViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _shoot
        };

        public IReadOnlyList<IComponentsCompose> Composes => new IComponentsCompose[]
        {
            _components,
            _states,
            _network
        };
    }
}