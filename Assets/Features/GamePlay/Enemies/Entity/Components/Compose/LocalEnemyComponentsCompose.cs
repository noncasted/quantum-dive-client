using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Components.Common;
using GamePlay.Enemies.Entity.Components.DamageProcessors.Runtime;
using GamePlay.Enemies.Entity.Components.Health.Runtime;
using GamePlay.Enemies.Entity.Components.Sorting.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Components.TargetSearchers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "LocalEnemyComponentsCompose",
        menuName = EnemyComponentsRoutes.Root + "Compose/Local")]
    public class LocalEnemyComponentsCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private DefaultCallbacksComponentFactory _callbacks;
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