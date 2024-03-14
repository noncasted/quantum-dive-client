
using Internal.Scopes.Abstract.Lifetimes;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Idles.Common;
using Global.System.Updaters.Runtime.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Idles.Remote
{
    public class PlayerRemoteIdle : IPlayerRemoteState, IUpdatable, IEntitySwitchLifetimeListener
    {
        public PlayerRemoteIdle(
            IRemoteRotation rotation,
            IUpdater updater,
            IRemoteStateMachine stateMachine,
            IEnhancedAnimator animator,
            IAnimation animation,
            IdleDefinition definition)
        {
            _rotation = rotation;
            _updater = updater;
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IRemoteRotation _rotation;
        private readonly IUpdater _updater;
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnhancedAnimator _animator;
        private readonly IAnimation _animation;
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
            //_animation.SetOrientation(_rotation.Orientation);
        }
    }
}