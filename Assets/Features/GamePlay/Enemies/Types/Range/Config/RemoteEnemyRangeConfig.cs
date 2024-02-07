using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Components.Health.Runtime;
using GamePlay.Enemies.Entity.Components.Sorting.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Definition.Config;
using GamePlay.Enemies.Entity.Network.Properties.Runtime;
using GamePlay.Enemies.Entity.States.Damaged.Remote;
using GamePlay.Enemies.Entity.States.Death.Remote;
using GamePlay.Enemies.Entity.States.Following.Remote;
using GamePlay.Enemies.Entity.States.Idle.Remote;
using GamePlay.Enemies.Entity.States.Respawn.Remote;
using GamePlay.Enemies.Entity.Views.Transforms.Remote.Runtime;
using GamePlay.Enemies.Types.Range.States.Shoot.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Range.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRangeConfigRoutes.RemoteName,
        menuName = EnemyRangeConfigRoutes.RemotePath)]
    public class RemoteEnemyRangeConfig : ScriptableObject, IRemoteEnemyConfig
    {
        [SerializeField] private RemoteStateMachineFactory _remoteStateMachine;
        [SerializeField] private TransformSyncFactory _transformSync;
        [SerializeField] private RemoteIdleFactory _idle;
        [SerializeField] private RemoteFollowingFactory _following;
        [SerializeField] private RemoteRespawnFactory _respawn;
        [SerializeField] private RemoteShootFactory _shoot;
        [SerializeField] private RemoteDamagedFactory _damaged;
        [SerializeField] private RemoteDeathFactory _death;
        [SerializeField] private SpriteSortingFactory _spriteSorting;
        [SerializeField] private NetworkPropertiesFactory _networkPropertiesInjector;
        [SerializeField] private HealthFactory _health;

        public IComponentFactory[] GetAssets()
        {
            return new IComponentFactory[]
            {
                _remoteStateMachine,
                _transformSync,
                _idle,
                _following,
                _respawn,
                _shoot,
                _damaged,
                _death,
                _spriteSorting,
                _networkPropertiesInjector,
                _health,
            };
        }

        public ScopedEntityViewFactory Prefab { get; }
        public IReadOnlyList<IComponentFactory> Components { get; }
        public IReadOnlyList<IComponentsCompose> Composes { get; }
    }
}