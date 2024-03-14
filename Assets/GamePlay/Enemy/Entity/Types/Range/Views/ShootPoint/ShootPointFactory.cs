using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.Views.ShootPoint
{
    public class ShootPointFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private Transform _point;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<ShootPoint>()
                .WithParameter(_point)
                .As<IShootPoint>();
        }
    }
}