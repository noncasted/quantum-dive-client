using Common.Architecture.Entities.Runtime.Callbacks;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Runs.Remote
{
    public class RemoteRun : IPlayerRemoteState, IUpdatable, IEntitySwitchListener
    {
        public RemoteRun(
            IUpdater updater,
            IRemoteStateMachine stateMachine,
            IPlayerAnimator animator,
            IPlayerSpriteFlip spriteFlip,
            IRunInputSync inputSync,
            RunAnimation animation,
            RunDefinition definition)
        {
            _updater = updater;
            _stateMachine = stateMachine;
            _animator = animator;
            _spriteFlip = spriteFlip;
            _inputSync = inputSync;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IUpdater _updater;
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IPlayerAnimator _animator;
        private readonly IPlayerSpriteFlip _spriteFlip;
        private readonly IRunInputSync _inputSync;
        private readonly RunAnimation _animation;
        private readonly RunDefinition _definition;
        
        public void OnEnabled()
        {
            _stateMachine.RegisterState(_definition, this);
        }

        public void OnDisabled()
        {
            _stateMachine.UnregisterState(_definition);
        }
        
        public void Enter(RagonBuffer buffer)
        {
            _animator.PlayLooped(_animation);
            _updater.Add(this);
        }

        public void Break()
        {
            _updater.Remove(this);
        }

        public void OnUpdate(float delta)
        {
            _animation.SetOrientation(_inputSync.Orientation);
            _spriteFlip.FlipAlong(_inputSync.Angle);
        }
    }
}