using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Logs;
using GamePlay.Enemy.Entity.Views.Animators.Logs;
using GamePlay.Enemy.Entity.Views.RigidBodies.Logs;
using GamePlay.Enemy.Entity.Views.Sprites.Logs;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Logs;
using GamePlay.Enemy.Entity.Views.Transforms.Remote.Logs;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Debugs.Flags
{
    public class EnemyDebugFlags : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private LocalTransformDebugFlag _localTransform;
        [SerializeField] private RemoteTransformDebugFlag _remoteTransform;
        [SerializeField] private AnimatorDebugFlag _animator;
        [SerializeField] private SpriteDebugFlag _sprite;
        [SerializeField] private RigidBodyDebugFlag _rigidBody;
        [SerializeField] private RemoteStateMachineDebugFlag _remoteStateMachine;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.RegisterInstance(_localTransform);
            services.RegisterInstance(_remoteTransform);
            services.RegisterInstance(_animator);
            services.RegisterInstance(_sprite);
            services.RegisterInstance(_rigidBody);
            services.RegisterInstance(_remoteStateMachine);
        }
    }
}