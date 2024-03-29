﻿using System;
using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Root.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Definition.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Remote;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Common.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Definition.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowConfigRoutes.RemoteName,
        menuName = BowConfigRoutes.RemotePath)]
    public class RemoteBowConfig : ScriptableObject, IEquipmentInstanceConfig
    {
        [SerializeField] private EntityDefaultCallbacksFactory _defaultCallbacks;
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

        [SerializeField] private RemoteBowViewFactoryFactory _prefab;

        public EquipmentViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _defaultCallbacks,
            _root,
            _aim,
            _reload,
            _shoot,
            _strafes,
            _projectileStarter,
        };
        
        public IReadOnlyList<IComponentsCompose> Composes => Array.Empty<IComponentsCompose>();
    }
}