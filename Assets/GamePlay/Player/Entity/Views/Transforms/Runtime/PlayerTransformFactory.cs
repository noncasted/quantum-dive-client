using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Runtime
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