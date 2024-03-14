using System;
using GamePlay.Enemy.Entity.Views.RigidBodies.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.RigidBodies.Runtime
{
    [Serializable]
    public class EnemyRigidBodyFactory : IComponentFactory
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CircleCollider2D _collider;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private RigidBodyLogSettings _logSettings;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RigidBodyLogger>()
                .WithParameter(_logSettings);

            services.Register<MoveCaster>()
                .WithParameter(_collider)
                .WithParameter(_layerMask);

            services.Register<EnemyRigidBody>()
                .As<IEnemyRigidBody>()
                .WithParameter(_rigidbody)
                .WithParameter(_collider)
                .WithParameter(_layerMask)
                .AsCallbackListener();
        }
    }
}