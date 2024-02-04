using GamePlay.Enemies.Entity.Components.Health.Runtime;
using GamePlay.Enemies.Entity.Components.Sorting.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Network.Properties.Runtime;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Setup.Config.Remote;
using GamePlay.Enemies.Entity.States.Damaged.Remote;
using GamePlay.Enemies.Entity.States.Death.Remote;
using GamePlay.Enemies.Entity.States.Following.Remote;
using GamePlay.Enemies.Entity.States.Idle.Remote;
using GamePlay.Enemies.Entity.States.Respawn.Remote;
using GamePlay.Enemies.Entity.Views.Transforms.Remote.Runtime;
using GamePlay.Enemies.Types.Melee.States.Attack.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeConfigRoutes.RemoteName,
        menuName = EnemyMeleeConfigRoutes.RemotePath)]
    public class RemoteEnemyMeleeConfig : RemoteEnemyComponents
    {
        [SerializeField] private RemoteStateMachineFactory _remoteStateMachine;
        [SerializeField] private TransformSyncFactory _transformSync;
        [SerializeField] private RemoteIdleFactory _idle;
        [SerializeField] private RemoteRespawnFactory _respawn;
        [SerializeField] private RemoteDamagedFactory _damaged;
        [SerializeField] private RemoteDeathFactory _death;
        [SerializeField] private RemoteFollowingFactory _following;
        [SerializeField] private RemoteMeleeAttackFactory _meleeAttack;
        [SerializeField] private SpriteSortingFactory _spriteSorting;
        [SerializeField] private NetworkPropertiesFactory _networkPropertiesInjector;
        [SerializeField] private HealthFactory _health;

        public override IComponentFactory[] GetAssets()
        {
            return new IComponentFactory[]
            {
                _remoteStateMachine,
                _transformSync,
                _idle,
                _respawn,
                _damaged,
                _death,
                _meleeAttack,
                _spriteSorting,
                _networkPropertiesInjector,
                _following,
                _health
            };
        }
    }
}