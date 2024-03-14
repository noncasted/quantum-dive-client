using System;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Damaged.Vfx
{
    [Serializable]
    public class DamagedVfxFactory : IComponentFactory
    {
        [SerializeField] private DamagedVfx _vfx;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.RegisterInstance(_vfx)
                .As<IDamagedVfx>();
        }
    }
}