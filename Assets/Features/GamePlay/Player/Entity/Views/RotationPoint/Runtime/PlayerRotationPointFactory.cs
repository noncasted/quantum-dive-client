using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RotationPoint.Runtime
{
    [Serializable]
    public class PlayerRotationPointFactory : IComponentFactory
    {
        [SerializeField] private Transform _rotationPoint;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<PlayerRotationPoint>()
                .As<IPlayerRotationPoint>()
                .WithParameter(_rotationPoint);
        }
    }
}