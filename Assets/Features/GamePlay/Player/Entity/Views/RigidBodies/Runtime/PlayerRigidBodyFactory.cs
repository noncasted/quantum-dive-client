using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Views.RigidBodies.Debug.Gizmos;
using GamePlay.Player.Entity.Views.RigidBodies.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RigidBodies.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerRigidBodyFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private RigidBodyGizmosConfig _gizmosConfig;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CircleCollider2D _collider;
        [SerializeField] private ContactFilter2D _contactFilter;
        [SerializeField] private RigidBodyLogSettings _logSettings;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RigidBodyLogger>()
                .WithParameter(_logSettings);

            services.Register<PlayerRigidBody>()
                .As<IPlayerRigidBody>()
                .WithParameter(_rigidbody)
                .WithParameter(_collider)
                .WithParameter(_contactFilter)
                .AsCallbackListener();

            services.Register<RigidBodyGizmosDrawer>()
                .WithParameter<IGizmosConfig>(_gizmosConfig)
                .As<IRigidBodyGizmosDrawer>();
        }
    }
}