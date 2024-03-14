using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RotationPoint.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerRotationPointFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private Transform _rotationPoint;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<PlayerRotationPoint>()
                .As<IPlayerRotationPoint>()
                .WithParameter(_rotationPoint);
        }
    }
}