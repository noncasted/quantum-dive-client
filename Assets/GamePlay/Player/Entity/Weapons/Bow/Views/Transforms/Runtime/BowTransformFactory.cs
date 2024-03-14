using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime
{
    [DisallowMultipleComponent]
    public class BowTransformFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private Transform _transform;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<BowTransform>()
                .As<IBowTransform>()
                .WithParameter(_transform);
        }
    }
}