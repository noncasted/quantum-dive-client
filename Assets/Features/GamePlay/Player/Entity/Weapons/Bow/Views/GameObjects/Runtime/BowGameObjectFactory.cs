using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime
{
    [Serializable]
    public class BowGameObjectFactory : IComponentFactory
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<BowGameObject>()
                .As<IBowGameObject>()
                .WithParameter(_gameObject);
        }
    }
}