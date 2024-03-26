using GamePlay.Player.Entity.Views.Physics.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerPhysicsFactory : MonoBehaviour, IComponentFactory
    {
        //[SerializeField] private RigidBodyGizmosConfig _gizmosConfig;
        [SerializeField] private PlayerPhysicsView _view;
        [SerializeField] private PlayerPhysicsConfig _config;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<PlayerPhysics>()
                .As<IPlayerPhysics>()
                .WithParameter(_config)
                .WithParameter(_view)
                .AsCallbackListener();

            // services.Register<RigidBodyGizmosDrawer>()
            //     .WithParameter<IGizmosConfig>(_gizmosConfig) 
            //     .As<IRigidBodyGizmosDrawer>();
        }
    }
}