using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.Common.Definition.Config;
using GamePlay.Enemy.Entity.Components.Compose;
using GamePlay.Enemy.Entity.Components.Network.Compose;
using GamePlay.Enemy.Entity.States.Compose;
using GamePlay.Enemy.Entity.Types.Range.States.Shoot.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.Config
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
        
        public EnemyViewFactory Prefab => _prefab;

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