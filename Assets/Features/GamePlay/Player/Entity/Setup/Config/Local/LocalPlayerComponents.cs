using GamePlay.Player.Entity.Components.DamageProcessors.Runtime;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.Sorting.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.Equipment.Equipper.Local;
using GamePlay.Player.Entity.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Equipment.Locker.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using GamePlay.Player.Entity.Network.Sync.Properties.Runtime;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Setup.Config.Common;
using GamePlay.Player.Entity.States.Deaths.Local;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.States.Idles.Local;
using GamePlay.Player.Entity.States.None.Runtime;
using GamePlay.Player.Entity.States.Respawns.Local;
using GamePlay.Player.Entity.States.Roll.Local;
using GamePlay.Player.Entity.States.Runs.Local;
using GamePlay.Player.Entity.States.Runs.Remote;
using GamePlay.Player.Entity.States.SubStates.Damaged.Local;
using GamePlay.Player.Entity.States.SubStates.Movement.Runtime;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Player.Entity.Weapons.Combo.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Config.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerConfigRoutes.LocalName,
        menuName = PlayerConfigRoutes.LocalPath)]
    public class LocalPlayerComponents : ScriptableObject
    {
        [FoldoutGroup("System")] [SerializeField]
        private RotationFactory _rotation;
        [FoldoutGroup("System")] [SerializeField]
        private StateMachineFactory _stateMachine;
        [FoldoutGroup("System")] [SerializeField]
        private DamageProcessorFactory _damageProcessor;
        [FoldoutGroup("Data")] [SerializeField]
        private HealthFactory _health;
        [FoldoutGroup("System")] [SerializeField]
        private SpriteSortingFactory _spriteSorting;
        
        [FoldoutGroup("Equipment")] [SerializeField]
        private EquipmentLockerFactory _equipmentLocker;
        [FoldoutGroup("Equipment")] [SerializeField]
        private EquipmentSlotsStorageFactory _equipmentSlotsStorage;
        [FoldoutGroup("Equipment")] [SerializeField]
        private EquipperFactory _equipper;

        [FoldoutGroup("States")] [SerializeField]
        private FloatingStateFactory _floating;
        [FoldoutGroup("States")] [SerializeField]
        private LocalIdleFactory _idle;
        [FoldoutGroup("States")] [SerializeField]
        private NoneFactory _none;
        [FoldoutGroup("States")] [SerializeField]
        private LocalRespawnFactory _respawn;
        [FoldoutGroup("States")] [SerializeField]
        private RunFactory _run;
        [FoldoutGroup("States")] [SerializeField]
        private LocalDeathFactory _death;
        [FoldoutGroup("States")] [SerializeField]
        private LocalDamagedFactory _damaged;
        [FoldoutGroup("States")] [SerializeField]
        private LocalRollFactory _roll;

        [FoldoutGroup("System")] [SerializeField]
        private ComboStateMachineFactory _comboStateMachine;

        [FoldoutGroup("SubStates")] [SerializeField]
        private SubMovementFactory _subMovement;
        [FoldoutGroup("SubStates")] [SerializeField]
        private SubPushFactory _subPush;

        [FoldoutGroup("Network")] [SerializeField]
        private NetworkPropertiesFactory _networkProperties;
        [FoldoutGroup("Network")] [SerializeField]
        private RotationSyncFactory _rotationSync;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteStateMachineFactory _remoteStateMachine;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteEquipperFactory _remoteEquipper;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteRunFactory _remoteRun;

        public IComponentFactory[] GetAssets()
        {
            return new IComponentFactory[]
            {
                _rotation,
                _stateMachine,
                _damageProcessor,
                _health,
                _spriteSorting,

                _equipmentLocker,
                _equipmentSlotsStorage,
                _equipper,

                _floating,
                _idle,
                _none,
                _respawn,
                _run,
                _death,
                _damaged,
                _roll,
                
                _comboStateMachine,

                _subMovement,
                _subPush,
                
                _networkProperties,
                _rotationSync,
                _remoteStateMachine,
                _remoteEquipper,
                _remoteRun
            };
        }
    }
}