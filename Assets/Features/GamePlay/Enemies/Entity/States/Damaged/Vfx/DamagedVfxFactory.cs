using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Damaged.Vfx
{
    [Serializable]
    public class DamagedVfxFactory : IEnemyComponentFactory
    {
        [SerializeField] private DamagedVfx _vfx;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.RegisterInstance(_vfx)
                .As<IDamagedVfx>();
        }
    }
}