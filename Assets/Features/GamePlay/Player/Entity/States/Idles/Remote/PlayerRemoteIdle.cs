using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Idles.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Idles.Remote
{
    public class PlayerRemoteIdle : IPlayerRemoteState, IUpdatable, IEntitySwitchLifetimeListener
    {
        public PlayerRemoteIdle(
            IRemoteRotation rotation,
            IPlayerSpriteFlip spriteFlip,
            IUpdater updater,
            IRemoteStateMachine stateMachine,
            IPlayerAnimator animator,
            IdleAnimation animation,
            IdleDefinition definition)
        {
            _rotation = rotation;
            _spriteFlip = spriteFlip;
            _updater = updater;
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IRemoteRotation _rotation;
        private readonly IPlayerSpriteFlip _spriteFlip;
        private readonly IUpdater _updater;
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IPlayerAnimator _animator;
        private readonly IdleAnimation _animation;
        private readonly IdleDefinition _definition;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }
        
        public void Enter(RagonBuffer buffer)
        {
            _updater.Add(this);
            _animator.PlayLooped(_animation);
        }

        public void Break()
        {
            _updater.Remove(this);
        }

        public void OnUpdate(float delta)
        {
            _animation.SetOrientation(_rotation.Orientation);
            _spriteFlip.FlipAlong(_rotation.Angle);
        }
    }
}