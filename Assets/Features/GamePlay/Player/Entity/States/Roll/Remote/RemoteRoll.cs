using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.DataTypes.Network;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Roll.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Roll.Remote
{
    public class RemoteRoll : IPlayerRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteRoll(
            IRemoteStateMachine stateMachine,
            IPlayerAnimator animator,
            RollAnimation animation,
            RollDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IPlayerAnimator _animator;
        private readonly RollAnimation _animation;
        private readonly RollDefinition _definition;

        private CancellationTokenSource _cancellation;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }
        
        public void Enter(RagonBuffer buffer)
        {
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