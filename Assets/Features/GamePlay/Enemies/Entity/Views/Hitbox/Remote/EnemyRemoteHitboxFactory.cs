using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Views.Hitbox.Common;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Hitbox.Remote
{
    [Serializable]
    public class EnemyRemoteHitboxFactory : IEnemyComponentFactory
    {
        [SerializeField] private Transform _origin;
        [SerializeField] private HitboxConfig _hitboxConfig;
        [SerializeField] private GizmosConfig _gizmosConfig;
        [SerializeField] private EnemyHitboxTrigger _trigger;

        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
        {
            services.Register<RemoteHitbox>()
                .WithParameter(_origin)
                .WithParameter<IHitboxConfig>(_hitboxConfig)
                .WithParameter<IHitboxTrigger>(_trigger)
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