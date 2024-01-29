﻿using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Damages
{
    [Serializable]
    public class MeleeDamageDealerFactory : IEnemyComponentFactory
    {
        [SerializeField] private DamageTrigger _trigger;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.RegisterComponent(_trigger)
                .As<IDamageTrigger>();

            services.Register<DamageDealer>()
                .AsCallbackListener();
        }
    }
}