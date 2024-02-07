using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.GameObjects
{
    [Serializable]
    public class EnemyObjectFactory : IComponentFactory
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<EnemyGameObject>()
                .As<IEnemyGameObject>()
                .WithParameter(_gameObject);
        }
    }
}