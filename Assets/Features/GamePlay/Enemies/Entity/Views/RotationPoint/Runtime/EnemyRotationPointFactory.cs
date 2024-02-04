using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.RotationPoint.Runtime
{
    [Serializable]
    public class EnemyRotationPointFactory : IComponentFactory
    {
        [SerializeField] private Transform _rotationPoint;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<EnemyRotationPoint>()
                .As<IEnemyRotationPoint>()
                .WithParameter(_rotationPoint);
        }
    }
}