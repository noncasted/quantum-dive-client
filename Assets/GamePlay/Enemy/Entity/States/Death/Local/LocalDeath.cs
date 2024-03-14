using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Death.Common;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using GamePlay.Enemy.Entity.Views.Hitbox.Local;
using GamePlay.Enemy.Entity.Views.Sprites.Abstract;

namespace GamePlay.Enemy.Entity.States.Death.Local
{
    public class LocalDeath : IDeath, IEnemyLocalState
    {
        public LocalDeath(
            ILocalStateMachine stateMachine,
            IEnemyAnimator animator,
            IEnemySpriteSwitcher spriteSwitcher,
            IHitbox hitbox,
            DeathAnimation animation,
            DeathDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _spriteSwitcher = spriteSwitcher;
            _hitbox = hitbox;
            _animation = animation;
            _definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IEnemySpriteSwitcher _spriteSwitcher;
        private readonly IHitbox _hitbox;

        private readonly DeathAnimation _animation;
        private readonly DeathDefinition _definition;

        private CancellationTokenSource _cancellation;
        
        public EnemyStateDefinition Definition => _definition;

        public event Action Died;

        public void Enter()
        {
            _hitbox.Disable();
            Process().Forget();
        }
        
        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }

        private async UniTaskVoid Process()
        {
            _stateMachine.Enter(this);

            _cancellation = new CancellationTokenSource();

            await _animator.PlayAsync(_animation, _cancellation.Token);
            
            _spriteSwitcher.Disable();
            
            Died?.Invoke();
        }
    }
}