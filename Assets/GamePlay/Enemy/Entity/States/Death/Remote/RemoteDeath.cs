using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Death.Common;
using GamePlay.Enemy.Entity.Views.Animators.Runtime;
using GamePlay.Enemy.Entity.Views.Sprites.Runtime;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.States.Death.Remote
{
    public class RemoteDeath : IEnemyRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteDeath(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            IEnemySpriteSwitcher spriteSwitcher,
            DeathAnimation animation,
            DeathDefinition definition)
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
        
        private readonly DeathAnimation _animation;
        private readonly DeathDefinition _definition;

        private CancellationTokenSource _cancellation;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
            _spriteSwitcher.Disable();
        }

        public void Enter(RagonBuffer buffer)
        {
            Process().Forget();
        }

        private async UniTask Process()
        {
            _cancellation = new CancellationTokenSource();
            
            await _animator.PlayAsync(_animation, _cancellation.Token);
            
            _spriteSwitcher.Disable();
        }

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}