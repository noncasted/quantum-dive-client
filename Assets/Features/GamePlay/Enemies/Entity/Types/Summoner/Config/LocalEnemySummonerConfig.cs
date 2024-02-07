using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Components.Compose;
using GamePlay.Enemies.Entity.Definition.Config;
using GamePlay.Enemies.Entity.Network.Compose;
using GamePlay.Enemies.Entity.States.Compose;
using GamePlay.Enemies.Entity.Types.Summoner.States.StateSelector.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Summoner.Config
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