using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.States.Damaged.Common;
using GamePlay.Enemies.Entity.States.Damaged.Vfx;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using Ragon.Protocol;

namespace GamePlay.Enemies.Entity.States.Damaged.Remote
{
    public class RemoteDamaged : IEnemyRemoteState, IEntitySwitchListener
    {
        public RemoteDamaged(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            IDamagedVfx vfx,
            DamagedAnimation animation,
            DamagedDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _vfx = vfx;
            _animation = animation;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IDamagedVfx _vfx;
        
        private readonly DamagedAnimation _animation;
        private readonly DamagedDefinition _definition;

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
            var angle = buffer.ReadFloat(0, 360, 1f);
            _vfx.Play(angle);
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