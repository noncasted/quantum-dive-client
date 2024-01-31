using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Types.Range.Views.ShootPoint
{
    [Serializable]
    public class ShootPointFactory : IEnemyComponentFactory
    {
        [SerializeField] private Transform _point;
        
        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
        {
            services.Register<ShootPoint>()
                .WithParameter(_point)
                .As<IShootPoint>();
        }
    }
}