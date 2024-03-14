using System;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.HealthBars.Runtime
{
    [Serializable]
    public class HealthBarFactory : IComponentFactory
    {
        [SerializeField] private HealthBarCell _cellPrefab;
        [SerializeField] private Transform _cellsRoot;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<HealthBar>()
                .WithParameter(_cellPrefab)
                .WithParameter(_cellsRoot)
                .AsCallbackListener();
        }
    }
}