using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.HealthBars.Runtime
{
    [Serializable]
    public class HealthBarFactory : IEnemyComponentFactory
    {
        [SerializeField] private HealthBarCell _cellPrefab;
        [SerializeField] private Transform _cellsRoot;

        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
        {
            services.Register<HealthBar>()
                .WithParameter(_cellPrefab)
                .WithParameter(_cellsRoot)
                .AsCallbackListener();
        }
    }
}