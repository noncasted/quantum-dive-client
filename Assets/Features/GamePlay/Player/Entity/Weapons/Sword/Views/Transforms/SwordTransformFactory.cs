using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.Transforms
{
    [DisallowMultipleComponent]
    public class SwordTransformFactory : MonoBehaviour, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SwordTransform>()
                .WithParameter(transform)
                .As<ISwordTransform>();
        }
    }
}