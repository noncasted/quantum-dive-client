using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime
{
    [DisallowMultipleComponent]
    public class BowGameObjectFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowGameObject>()
                .As<IBowGameObject>()
                .WithParameter(_gameObject);
        }
    }
}