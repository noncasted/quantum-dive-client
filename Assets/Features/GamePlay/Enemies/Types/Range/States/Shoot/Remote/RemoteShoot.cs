using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using GamePlay.Enemies.Types.Range.States.Shoot.Common;
using Ragon.Protocol;

namespace GamePlay.Enemies.Types.Range.States.Shoot.Remote
{
    public class RemoteShoot : IEnemyRemoteState, IEntitySwitchListener
    {
        public RemoteShoot(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            ShootAnimation animation,
            ShootDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly ShootAnimation _animation;
        private readonly ShootDefinition _definition;

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