using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RotationPoint.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerRotationPointFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private Transform _rotationPoint;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<PlayerRotationPoint>()
                .As<IPlayerRotationPoint>()
                .WithParameter(_rotationPoint);
        }
    }
}