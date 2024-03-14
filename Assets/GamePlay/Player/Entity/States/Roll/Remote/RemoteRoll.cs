using System.Threading;

using Internal.Scopes.Abstract.Lifetimes;
using Common.DataTypes.Network;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Roll.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using Internal.Scopes.Abstract.Instances.Entities;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Roll.Remote
{
    public class RemoteRoll : IPlayerRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteRoll(
            IRemoteStateMachine stateMachine,
            IEnhancedAnimator animator,
            IAnimation animation,
            RollDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnhancedAnimator _animator;
        private readonly IAnimation _animation;
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