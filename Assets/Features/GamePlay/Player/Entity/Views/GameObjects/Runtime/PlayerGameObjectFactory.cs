using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.GameObjects.Runtime
{
    [Serializable]
    public class PlayerGameObjectFactory : IComponentFactory
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<PlayerGameObject>()
                .As<IPlayerGameObject>()
                .WithParameter(_gameObject);
        }
    }
}