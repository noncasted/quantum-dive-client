using System.Threading;
using Common.DataTypes.Network;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Roll.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Roll.Remote
{
    public class RemoteRoll : IPlayerRemoteState, IPlayerSwitchListener
    {
        public RemoteRoll(
            IRemoteStateMachine stateMachine,
            IPlayerAnimator animator,
            IPlayerSpriteFlip spriteFlip,
            RollAnimation animation,
            RollDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _spriteFlip = spriteFlip;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IPlayerAnimator _animator;
        private readonly IPlayerSpriteFlip _spriteFlip;
        private readonly RollAnimation _animation;
        private readonly RollDefinition _definition;

        private CancellationTokenSource _cancellation;

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
            var direction = buffer.ReadDirection();
            
            _spriteFlip.FlipAlong(direction, true);
            _animator.PlayAsync(_animation, _cancellation.Token).Forget();
        }

        public void Break()
        {
            Cancel();
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}