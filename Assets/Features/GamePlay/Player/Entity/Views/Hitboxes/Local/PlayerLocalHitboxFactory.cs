﻿using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Views.Hitboxes.Common;
using GamePlay.Player.Entity.Views.Hitboxes.Debug;
using GamePlay.Player.Entity.Views.Hitboxes.Network;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Hitboxes.Local
{
    [Serializable]
    public class PlayerLocalHitboxFactory : IComponentFactory
    {
        [SerializeField] [Indent] private HitboxConfigAsset _hitboxConfig;
        [SerializeField] [Indent] private HitboxGizmosConfig _gizmosConfig;
        [SerializeField] [Indent] private Transform _point;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<LocalHitbox>()
                .WithParameter<IHitboxConfig>(_hitboxConfig)
                .WithParameter(_point)
                .As<IHitbox>()
                .AsCallbackListener();

            services.Register<HitboxGizmosDrawer>()
                .WithParameter<IHitboxGizmosConfig>(_gizmosConfig)
                .WithParameter<IHitboxConfig>(_hitboxConfig)
                .WithParameter(_point)
                .AsCallbackListener();

            services.Register<HitboxSync>()
                .As<IHitboxSync>();
        }
    }
}