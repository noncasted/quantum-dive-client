﻿using GamePlay.Player.Entity.Views.Hitboxes.Common;
using GamePlay.Player.Entity.Views.Hitboxes.Debug;
using GamePlay.Player.Entity.Views.Hitboxes.Network;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Hitboxes.Remote
{
    [DisallowMultipleComponent]
    public class PlayerRemoteHitboxFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] [Indent] private HitboxConfigAsset _hitboxConfig;
        [SerializeField] [Indent] private HitboxGizmosConfig _gizmosConfig;
        [SerializeField] [Indent] private Transform _point;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemoteHitbox>()
                .WithParameter<IHitboxConfig>(_hitboxConfig)
                .WithParameter(_point)
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