using System.Collections.Generic;
using GamePlay.Enemy.Entity.Components.Common;
using GamePlay.Enemy.Entity.Components.Health.Runtime;
using GamePlay.Enemy.Entity.Components.Sorting.Runtime;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Runtime;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Common.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "RemoteEnemyComponentsCompose",
        menuName = EnemyComponentsRoutes.Root + "Compose/Remote")]
    public class RemoteEnemyComponentsCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private EntityDefaultCallbacksFactory _callbacks;
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