using System;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime
{
    [Serializable]
    public class EnemyTransformFactory : IComponentFactory
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private TransformLogSettings _logSettings;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<TransformLogger>()
                .WithParameter(_logSettings);

            services.Register<EnemyTransform>()
                .AsImplementedInterfaces()
                .WithParameter(_transform);
        }
    }
}