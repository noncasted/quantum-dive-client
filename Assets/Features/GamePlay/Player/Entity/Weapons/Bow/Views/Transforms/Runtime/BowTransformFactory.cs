using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime
{
    [DisallowMultipleComponent]
    public class BowTransformFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private Transform _transform;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowTransform>()
                .As<IBowTransform>()
                .WithParameter(_transform);
        }
    }
}