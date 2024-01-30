using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    [DisallowMultipleComponent]
    public class BowShootPointFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private ShootPointProvider _shootPoints;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowShootPoint>()
                .As<IBowShootPoint>()
                .WithParameter(_shootPoints);
        }
    }
}