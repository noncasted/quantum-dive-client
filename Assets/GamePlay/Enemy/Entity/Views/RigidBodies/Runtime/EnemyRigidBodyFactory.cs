using System;
using GamePlay.Enemy.Entity.Views.RigidBodies.Abstract;
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
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
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