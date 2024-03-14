using System;
using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Root.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Definition.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Local;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Local;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Local;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Common.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Definition.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowConfigRoutes.LocalName,
        menuName = BowConfigRoutes.LocalPath)]
    public class LocalBowConfig : ScriptableObject, IEquipmentInstanceConfig
    {
        [SerializeField] private EntityDefaultCallbacksFactory _defaultCallbacks;
        [SerializeField] private BowRootFactory _root;
        
        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private InputReceiverFactory _input;

        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private ProjectileStarterFactory _projectileStarter;

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

        public EquipmentViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _defaultCallbacks,
            _root,
            
            _input,
            _projectileStarter,
            _shoot,

            _aim,
            _reload,
            _strafes,
            _strafesInput
        };
        
        public IReadOnlyList<IComponentsCompose> Composes => Array.Empty<IComponentsCompose>();
    }
}