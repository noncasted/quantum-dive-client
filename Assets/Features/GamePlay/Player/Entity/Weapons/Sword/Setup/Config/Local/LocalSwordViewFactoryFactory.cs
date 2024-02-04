﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Views.Transforms;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Local
{
    [DisallowMultipleComponent]
    public class LocalSwordViewFactoryFactory : ScopedEntityViewFactory, IEntityViewFactory
    {
        [SerializeField] private AttackAreaFactory _attackArea;
        [SerializeField] private SwordTransformFactory _transform;
        
        public override void CreateViews(IServiceCollection services, IEntityUtils utils)
        {
            _attackArea.Create(services, utils);
            _transform.Create(services, utils);
        }
    }
}