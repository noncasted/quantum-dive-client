using System;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime
{
    [Serializable]
    public class EnemyTransformFactory : IComponentFactory
    {
        [SerializeField] private Transform _transform;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<EnemyTransform>()
                .AsImplementedInterfaces()
                .WithParameter(_transform);
        }
    }
}