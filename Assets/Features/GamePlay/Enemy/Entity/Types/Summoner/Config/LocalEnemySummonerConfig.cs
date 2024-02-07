using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Components.Compose;
using GamePlay.Enemy.Entity.Definition.Config;
using GamePlay.Enemy.Entity.Network.Compose;
using GamePlay.Enemy.Entity.States.Compose;
using GamePlay.Enemy.Entity.Types.Summoner.States.StateSelector.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Summoner.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemySummonerConfigRoutes.LocalName,
        menuName = EnemySummonerConfigRoutes.LocalPath)]
    public class LocalEnemySummonerConfig : ScriptableObject, ILocalEnemyConfig
    {
        [SerializeField] private LocalEnemyComponentsCompose _components;
        [SerializeField] private LocalEnemyStatesCompose _states;
        [SerializeField] private EnemyNetworkCompose _network;

        [SerializeField] private SummonerStateSelectorFactory _stateSelector;

        [SerializeField] private LocalEnemySummonerViewFactory _prefab;

        public ScopedEntityViewFactory Prefab => _prefab;
        
        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _stateSelector
        };

        public IReadOnlyList<IComponentsCompose> Composes => new IComponentsCompose[]
        {
            _components,
            _states,
            _network
        };
    }
}