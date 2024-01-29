using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime
{
    [Serializable]
    public class AttackAreaFactory : IComponentFactory
    {
        [SerializeField] private AttackAreaConfig _config;
        [SerializeField] private Collider2D _collider;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<AttackArea>()
                .WithParameter<IAttackAreaConfig>(_config)
                .WithParameter(_collider)
                .As<IAttackArea>();
        }
    }
}