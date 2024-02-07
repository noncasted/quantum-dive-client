using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Logs;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime
{
    [Serializable]
    public class EnemyTransformFactory : IComponentFactory
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private TransformLogSettings _logSettings;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<TransformLogger>()
                .WithParameter(_logSettings);

            services.Register<EnemyTransform>()
                .AsImplementedInterfaces()
                .WithParameter(_transform);
        }
    }
}