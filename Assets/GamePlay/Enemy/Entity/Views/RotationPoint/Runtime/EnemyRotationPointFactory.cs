using System;
using GamePlay.Enemy.Entity.Views.RotationPoint.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.RotationPoint.Runtime
{
    [Serializable]
    public class EnemyRotationPointFactory : IComponentFactory
    {
        [SerializeField] private Transform _rotationPoint;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<EnemyRotationPoint>()
                .As<IEnemyRotationPoint>()
                .WithParameter(_rotationPoint);
        }
    }
}