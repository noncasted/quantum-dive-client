using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime
{
    [DisallowMultipleComponent]
    public class BowArrowFactory : MonoBehaviour, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<BowArrow>()
                .As<IBowArrow>()
                .AsCallbackListener();
        }
    }
}