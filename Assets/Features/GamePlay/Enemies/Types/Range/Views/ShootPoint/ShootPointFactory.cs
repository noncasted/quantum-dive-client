using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Types.Range.Views.ShootPoint
{
    [Serializable]
    public class ShootPointFactory : IComponentFactory
    {
        [SerializeField] private Transform _point;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<ShootPoint>()
                .WithParameter(_point)
                .As<IShootPoint>();
        }
    }
}