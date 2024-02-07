using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Enemies.Entity.Components.Compose;
using Features.GamePlay.Enemies.Entity.Network.Compose;
using Features.GamePlay.Enemies.Entity.States.Compose;
using GamePlay.Enemies.Entity.Definition.Config;
using GamePlay.Enemies.Types.Melee.States.Attack.Local;
using GamePlay.Enemies.Types.Melee.States.StateSelector.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeConfigRoutes.LocalName,
        menuName = EnemyMeleeConfigRoutes.LocalPath)]
    public class LocalEnemyMeleeConfig : ScriptableObject, ILocalEnemyConfig
    {
        [SerializeField] private LocalEnemyComponentsCompose _components;
        [SerializeField] private LocalEnemyStatesCompose _states;
        [SerializeField] private EnemyNetworkCompose _network;

        [SerializeField] private LocalMeleeAttackFactory _localMeleeAttack;
        [SerializeField] private MeleeStateSelectorFactory _stateSelector;
        
        [SerializeField] private LocalEnemyMeleeViewFactory _prefab;
        
        public ScopedEntityViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _localMeleeAttack,
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