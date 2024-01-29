using GamePlay.Enemies.Entity.Components.DamageProcessors.Runtime;
using GamePlay.Enemies.Entity.Components.Health.Runtime;
using GamePlay.Enemies.Entity.Components.Sorting.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Components.TargetSearchers.Runtime;
using GamePlay.Enemies.Entity.Network.Properties.Runtime;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Setup.Config.Local;
using GamePlay.Enemies.Entity.States.Damaged.Local;
using GamePlay.Enemies.Entity.States.Death.Local;
using GamePlay.Enemies.Entity.States.Following.Local;
using GamePlay.Enemies.Entity.States.Idle.Local;
using GamePlay.Enemies.Entity.States.Respawn.Local;
using GamePlay.Enemies.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Enemies.Entity.Views.Transforms.Remote.Runtime;
using GamePlay.Enemies.Types.Range.States.Shoot.Local;
using GamePlay.Enemies.Types.Range.States.StateSelector.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Range.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRangeConfigRoutes.LocalName,
        menuName = EnemyRangeConfigRoutes.LocalPath)]
    public class LocalEnemyRangeConfig : LocalEnemyComponents
    {
        [FoldoutGroup("Components")] [SerializeField]
        private LocalStateMachineFactory _localStateMachine;
        [FoldoutGroup("Components")] [SerializeField]
        private RangeStateSelectorFactory _stateSelector;
        [FoldoutGroup("Components")] [SerializeField]
        private TargetSearcherFactory _targetSearcher;
        [FoldoutGroup("Components")] [SerializeField]
        private HealthFactory _health;
        [FoldoutGroup("Components")] [SerializeField]
        private DamageProcessorFactory _damageProcessor;
        [FoldoutGroup("Components")] [SerializeField]
        private SpriteSortingFactory _spriteSorting;

        [FoldoutGroup("States")] [SerializeField]
        private LocalIdleFactory _idle;
        [FoldoutGroup("States")] [SerializeField]
        private LocalRespawnFactory _respawn;
        [FoldoutGroup("States")] [SerializeField]
        private LocalFollowingFactory _following;
        [FoldoutGroup("States")] [SerializeField]
        private LocalShootFactory _shoot;
        [FoldoutGroup("States")] [SerializeField]
        private LocalDamagedFactory _damaged;
        [FoldoutGroup("States")] [SerializeField]
        private LocalDeathFactory _death;
        
        [FoldoutGroup("SubStates")] [SerializeField]
        private SubPushFactory _push;
        
        [FoldoutGroup("Remote")] [SerializeField]
        private RemoteStateMachineFactory _remoteStateMachine;
        [FoldoutGroup("Remote")] [SerializeField]
        private NetworkPropertiesFactory _networkPropertiesInjector;
        [FoldoutGroup("Remote")] [SerializeField]
        private TransformSyncFactory _transformSync;

        public override IEnemyComponentFactory[] GetAssets()
        {
            return new IEnemyComponentFactory[]
            {
                _localStateMachine,
                _targetSearcher,
                _stateSelector,
                _health,
                _damageProcessor,
                _spriteSorting,

                _idle,
                _respawn,
                _following,
                _shoot,
                _damaged,
                _push,
                _death,
                
                _remoteStateMachine,
                _networkPropertiesInjector,
                _transformSync
            };
        }
    }
}