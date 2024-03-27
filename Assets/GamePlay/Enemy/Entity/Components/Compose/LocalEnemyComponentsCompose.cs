using System.Collections.Generic;
using GamePlay.Enemy.Entity.Components.Common;
using GamePlay.Enemy.Entity.Components.DamageProcessors.Runtime;
using GamePlay.Enemy.Entity.Components.Healths.Runtime;
using GamePlay.Enemy.Entity.Components.Sorting.Runtime;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemy.Entity.Components.TargetSearchers.Runtime;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Common.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "LocalEnemyComponentsCompose",
        menuName = EnemyComponentsRoutes.Root + "Compose/Local")]
    public class LocalEnemyComponentsCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private EntityDefaultCallbacksFactory _callbacks;
        [SerializeField] private DamageProcessorFactory _damageProcessor;
        [SerializeField] private HealthFactory _health;
        [SerializeField] private SpriteSortingFactory _spriteSorting;
        [SerializeField] private LocalStateMachineFactory _localStateMachine;
        [SerializeField] private RemoteStateMachineFactory _remoteStateMachine;
        [SerializeField] private TargetSearcherFactory _targetSearcher;
        
        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _callbacks,
            _damageProcessor,
            _health,
            _spriteSorting,
            _localStateMachine,
            _remoteStateMachine,
            _targetSearcher
        };
    }
}