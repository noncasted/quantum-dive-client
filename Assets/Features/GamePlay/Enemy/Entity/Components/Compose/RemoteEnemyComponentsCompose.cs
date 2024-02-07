using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Components.Common;
using GamePlay.Enemies.Entity.Components.Health.Runtime;
using GamePlay.Enemies.Entity.Components.Sorting.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "RemoteEnemyComponentsCompose",
        menuName = EnemyComponentsRoutes.Root + "Compose/Remote")]
    public class RemoteEnemyComponentsCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private DefaultCallbacksComponentFactory _callbacks;
        [SerializeField] private HealthFactory _health;
        [SerializeField] private SpriteSortingFactory _spriteSorting;
        [SerializeField] private RemoteStateMachineFactory _remoteStateMachine;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _callbacks,
            _health,
            _spriteSorting,
            _remoteStateMachine
        };
    }
}