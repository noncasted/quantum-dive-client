using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Respawns.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Respawns.Remote
{
    public class PlayerRemoteRespawn : IPlayerRemoteState, IPlayerSwitchListener
    {
        public PlayerRemoteRespawn(
            IRemoteStateMachine stateMachine,
            IPlayerAnimator animator,
            RespawnAnimation animation,
            RespawnDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IPlayerAnimator _animator;
        private readonly RespawnAnimation _animation;
        private readonly RespawnDefinition _definition;

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
            _cancellation = new CancellationTokenSource();
            _animator.PlayAsync(_animation, _cancellation.Token).Forget();
        }

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}