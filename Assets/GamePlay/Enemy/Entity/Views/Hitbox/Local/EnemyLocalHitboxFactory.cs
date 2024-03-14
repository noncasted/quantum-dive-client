using System;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.Views.Hitbox.Common;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Hitbox.Local
{
    [Serializable]
    public class EnemyLocalHitboxFactory : IComponentFactory
    {
        [SerializeField] private HitboxConfig _hitboxConfig;
        [SerializeField] private Transform _origin;
        [SerializeField] private GizmosConfig _gizmosConfig;
        [SerializeField] private EnemyHitboxTrigger _trigger;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalHitbox>()
                .WithParameter(_origin)
                .WithParameter<IHitboxConfig>(_hitboxConfig)
                .WithParameter<IHitboxTrigger>(_trigger)
                .As<IHitbox>()
                .AsCallbackListener();

            services.Register<GizmosDrawer>()
                .WithParameter<IGizmosConfig>(_gizmosConfig)
                .WithParameter<IHitboxConfig>(_hitboxConfig)
                .WithParameter(_origin)
                .AsCallbackListener();

            services.Register<HitboxStateSync>()
                .As<IHitboxStateSync>()
                .AsSelf();
        }
    }
}