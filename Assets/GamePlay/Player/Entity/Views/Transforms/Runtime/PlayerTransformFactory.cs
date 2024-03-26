using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerTransformFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private Transform _transform;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
           services.Register<PlayerTransform>()
                .AsImplementedInterfaces()
                .WithParameter(_transform);
        }
    }
}