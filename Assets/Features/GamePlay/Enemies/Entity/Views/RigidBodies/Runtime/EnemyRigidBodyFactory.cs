using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Views.RigidBodies.Logs;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.RigidBodies.Runtime
{
    [Serializable]
    public class EnemyRigidBodyFactory : IEnemyComponentFactory
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CircleCollider2D _collider;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private RigidBodyLogSettings _logSettings;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
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