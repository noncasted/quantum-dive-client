using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Common.Definition.Config;
using GamePlay.Enemy.Entity.Components.Compose;
using GamePlay.Enemy.Entity.Components.Network.Compose;
using GamePlay.Enemy.Entity.States.Compose;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Summoner.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemySummonerConfigRoutes.RemoteName,
        menuName = EnemySummonerConfigRoutes.RemotePath)]
    public class RemoteEnemySummonerConfig : ScriptableObject, IRemoteEnemyConfig
    {
        [SerializeField] private RemoteEnemyComponentsCompose _components;
        [SerializeField] private RemoteEnemyStatesCompose _states;
        [SerializeField] private EnemyNetworkCompose _network;

        [SerializeField] private RemoteEnemySummonerViewFactory _prefab;
        
        public ScopedEntityViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
        };

        public IReadOnlyList<IComponentsCompose> Composes => new IComponentsCompose[]
        {
            _components,
            _states,
            _network
        };
    }
}