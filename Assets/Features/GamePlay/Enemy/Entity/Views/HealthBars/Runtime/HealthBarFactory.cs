using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.HealthBars.Runtime
{
    [Serializable]
    public class HealthBarFactory : IComponentFactory
    {
        [SerializeField] private HealthBarCell _cellPrefab;
        [SerializeField] private Transform _cellsRoot;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<HealthBar>()
                .WithParameter(_cellPrefab)
                .WithParameter(_cellsRoot)
                .AsCallbackListener();
        }
    }
}