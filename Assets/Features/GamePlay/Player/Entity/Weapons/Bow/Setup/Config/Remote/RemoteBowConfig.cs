﻿using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Player.Entity.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Remote;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Common;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Root.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowConfigRoutes.RemoteName,
        menuName = BowConfigRoutes.RemotePath)]
    public class RemoteBowConfig : ScriptableObject, IEquipmentInstanceConfig
    {
        [SerializeField] private DefaultCallbacksComponentFactory _defaultCallbacks;
        [SerializeField] private BowRootFactory _root;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private RemoteAimFactory _aim;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private RemoteReloadFactory _reload;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private RemoteShootFactory _shoot;

        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private RemoteStrafeFactory _strafes;

        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private ProjectileStarterFactory _projectileStarter;

        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private RemoteBowRotationFactory _rotation;

        [SerializeField] private RemoteBowViewFactory _prefab;

        public EntitySetupView Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _defaultCallbacks,
            _root,
            _aim,
            _reload,
            _shoot,
            _strafes,
            _projectileStarter,
            _rotation
        };
    }
}