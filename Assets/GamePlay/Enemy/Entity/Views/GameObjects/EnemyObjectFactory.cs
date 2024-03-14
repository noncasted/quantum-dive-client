using System;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.GameObjects
{
    [Serializable]
    public class EnemyObjectFactory : IComponentFactory
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<EnemyGameObject>()
                .As<IEnemyGameObject>()
                .WithParameter(_gameObject);
        }
    }
}