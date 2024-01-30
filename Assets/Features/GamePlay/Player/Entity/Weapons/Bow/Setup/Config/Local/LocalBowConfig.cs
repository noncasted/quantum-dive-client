using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Player.Entity.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ProjectilesAmount;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ShotDelays;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.Spreadings;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Local;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Common;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Root.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Local;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Local;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Local;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowConfigRoutes.LocalName,
        menuName = BowConfigRoutes.LocalPath)]
    public class LocalBowConfig : ScriptableObject, IEquipmentInstanceConfig
    {
        [SerializeField] private DefaultCallbacksComponentFactory _defaultCallbacks;
        [SerializeField] private BowRootFactory _root;
        
        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private InputReceiverFactory _input;

        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private ProjectileStarterFactory _projectileStarter;

        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private RotationFactory _rotation;

        [FoldoutGroup("Data")] [SerializeField] [Indent]
        private ProjectilesAmountDataFactory _projectilesAmountData;

        [FoldoutGroup("Data")] [SerializeField] [Indent]
        private ShotDelayDataFactory _shotDelayData;

        [FoldoutGroup("Data")] [SerializeField] [Indent]
        private SpreadingDataFactory _spreadingData;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private AimFactory _aim;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private ReloadFactory _reload;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private ShooterFactory _shoot;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private StrafeFactory _strafes;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private StrafeInputFactory _strafesInput;

        [SerializeField] private LocalBowViewFactory _prefab;

        public EntitySetupView Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _defaultCallbacks,
            _root,
            
            _input,
            _projectileStarter,
            _rotation,
            _shoot,

            _projectilesAmountData,
            _shotDelayData,
            _spreadingData,

            _aim,
            _reload,
            _strafes,
            _strafesInput
        };
    }
}