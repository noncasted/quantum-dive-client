using GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    [DisallowMultipleComponent]
    public class BowShootPointFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private ShootPointProvider _shootPoints;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<BowShootPoint>()
                .As<IBowShootPoint>()
                .WithParameter(_shootPoints);
        }
    }
}