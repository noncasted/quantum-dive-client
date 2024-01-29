using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.Sorting.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using GamePlay.Player.Entity.Network.Sync.Properties.Runtime;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Setup.Config.Common;
using GamePlay.Player.Entity.States.Idles.Remote;
using GamePlay.Player.Entity.States.Respawns.Remote;
using GamePlay.Player.Entity.States.Roll.Remote;
using GamePlay.Player.Entity.States.Runs.Remote;
using GamePlay.Player.Entity.States.SubStates.Damaged.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Config.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerConfigRoutes.RemoteName,
        menuName = PlayerConfigRoutes.RemotePath)]
    public class RemotePlayerComponents : ScriptableObject
    {
        [FoldoutGroup("System")] [SerializeField]
        private SpriteSortingFactory _spriteSorting;
        
        [FoldoutGroup("Equipment")] [SerializeField]
        private EquipmentSlotsStorageFactory _equipmentSlotsStorage;
        [FoldoutGroup("Equipment")] [SerializeField]
        private RemoteEquipperFactory _equipper;
            
        [FoldoutGroup("Network")] [SerializeField]
        private NetworkPropertiesFactory _networkProperties;
        [FoldoutGroup("Network")] [SerializeField]
        private RotationSyncFactory _rotationSync;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteStateMachineFactory _remoteStateMachine;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteIdleFactory _remoteIdle;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteRunFactory _remoteRun;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteRespawnFactory _remoteRespawn;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteDamagedFactory _remoteDamaged;
        [FoldoutGroup("Network")] [SerializeField]
        private RemoteRollFactory _remoteRoll;

        public IComponentFactory[] GetAssets()
        {
            return new IComponentFactory[]
            {
                _spriteSorting,
                
                _equipmentSlotsStorage,
                _equipper,
                
                _networkProperties,
                _rotationSync,
                _remoteStateMachine,
                
                _remoteIdle,
                _remoteRun,
                _remoteRespawn,
                _remoteDamaged,
                _remoteRoll
            };
        }
    }
}