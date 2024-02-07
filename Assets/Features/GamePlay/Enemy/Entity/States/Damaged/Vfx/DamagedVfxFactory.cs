using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Damaged.Vfx
{
    [Serializable]
    public class DamagedVfxFactory : IComponentFactory
    {
        [SerializeField] private DamagedVfx _vfx;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.RegisterInstance(_vfx)
                .As<IDamagedVfx>();
        }
    }
}