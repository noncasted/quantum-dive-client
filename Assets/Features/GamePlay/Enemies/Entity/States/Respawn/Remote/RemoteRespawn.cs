using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.States.Respawn.Common;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using GamePlay.Enemies.Entity.Views.Sprites.Runtime;
using Ragon.Protocol;

namespace GamePlay.Enemies.Entity.States.Respawn.Remote
{
    public class RemoteRespawn : IEnemyRemoteState, IEnemySwitchListener
    {
        public RemoteRespawn(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            IEnemySpriteSwitcher spriteSwitcher,
            RespawnAnimation animation,
            RespawnDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _spriteSwitcher = spriteSwitcher;
            _animation = animation;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IEnemySpriteSwitcher _spriteSwitcher;
        private readonly RespawnAnimation _animation;
        private readonly RespawnDefinition _definition;

        private CancellationTokenSource _cancellation;

        public void OnEnabled()
        {
            _stateMachine.RegisterState(_definition, this);
            _spriteSwitcher.Disable();
        }

        public void OnDisabled()
        {
            _stateMachine.UnregisterState(_definition);
        }

        public void Enter(RagonBuffer buffer)
        {
            _cancellation = new CancellationTokenSource();
            
            _spriteSwitcher.Enable();

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