using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Logs;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Views.Animators.Logs;
using GamePlay.Enemies.Entity.Views.RigidBodies.Logs;
using GamePlay.Enemies.Entity.Views.Sprites.Logs;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Logs;
using GamePlay.Enemies.Entity.Views.Transforms.Remote.Logs;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Debugs.Flags
{
    public class EnemyDebugFlags : MonoBehaviour, IEnemyContainerBuilder
    {
        [SerializeField] private LocalTransformDebugFlag _localTransform;
        [SerializeField] private RemoteTransformDebugFlag _remoteTransform;
        [SerializeField] private AnimatorDebugFlag _animator;
        [SerializeField] private SpriteDebugFlag _sprite;
        [SerializeField] private RigidBodyDebugFlag _rigidBody;
        [SerializeField] private RemoteStateMachineDebugFlag _remoteStateMachine;
        
        public void OnBuild(IServiceCollection services, ICallbackRegister callbacks)
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