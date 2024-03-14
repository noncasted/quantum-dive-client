using System.Collections.Generic;
using GamePlay.Enemy.Entity.Common.Definition.Config;
using GamePlay.Enemy.Entity.Components.Compose;
using GamePlay.Enemy.Entity.Components.Network.Compose;
using GamePlay.Enemy.Entity.States.Compose;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Local;
using GamePlay.Enemy.Entity.Types.Melee.States.StateSelector.Runtime;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.Config
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
        
        public EnemyViewFactory Prefab => _prefab;

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