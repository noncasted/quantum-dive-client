using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Local.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Local.Runtime
{
    [Serializable]
    public class PlayerTransformFactory : IComponentFactory
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private TransformLogSettings _logSettings;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<TransformLogger>()
                .WithParameter(_logSettings);

            services.Register<PlayerTransform>()
                .AsImplementedInterfaces()
                .WithParameter(_transform);
        }
    }
}