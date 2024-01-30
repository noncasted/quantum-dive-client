using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.Transforms.Local.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Local.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerTransformFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private TransformLogSettings _logSettings;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<TransformLogger>()
                .WithParameter(_logSettings);

            services.Register<PlayerTransform>()
                .AsImplementedInterfaces()
                .WithParameter(_transform);
        }
    }
}