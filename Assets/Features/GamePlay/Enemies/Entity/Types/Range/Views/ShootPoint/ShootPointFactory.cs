using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Range.Views.ShootPoint
{
    public class ShootPointFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private Transform _point;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<ShootPoint>()
                .WithParameter(_point)
                .As<IShootPoint>();
        }
    }
}