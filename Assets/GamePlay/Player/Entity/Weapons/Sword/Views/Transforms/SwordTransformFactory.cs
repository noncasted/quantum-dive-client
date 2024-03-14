using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.Transforms
{
    [DisallowMultipleComponent]
    public class SwordTransformFactory : MonoBehaviour, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<SwordTransform>()
                .WithParameter(transform)
                .As<ISwordTransform>();
        }
    }
}