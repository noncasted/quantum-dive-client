using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Views.Physics.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerPhysicsFactory : MonoBehaviour, IComponentFactory
    {
        //[SerializeField] private RigidBodyGizmosConfig _gizmosConfig;
        [SerializeField] private PlayerPhysicsView _view;
        [SerializeField] private PhysicsLogSettings _logSettings;
        [SerializeField] private PlayerPhysicsConfig _config;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<PhysicsLogger>()
                .WithParameter(_logSettings);

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