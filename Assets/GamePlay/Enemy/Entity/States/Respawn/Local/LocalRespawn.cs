using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.Health.Runtime;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Respawn.Common;
using GamePlay.Enemy.Entity.Views.Animators.Runtime;
using GamePlay.Enemy.Entity.Views.Hitbox.Local;
using GamePlay.Enemy.Entity.Views.Sprites.Runtime;
using Internal.Scopes.Abstract.Instances.Services;

namespace GamePlay.Enemy.Entity.States.Respawn.Local
{
    public class LocalRespawn : IRespawn, IEnemyLocalState, IScopeSwitchListener
    {
        public LocalRespawn(
            ILocalStateMachine stateMachine,
            IEnemyAnimator animator,
            IEnemySpriteSwitcher spriteSwitcher,
            IHitbox hitbox,
            IHealth health,
            RespawnAnimation animation,
            RespawnDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _spriteSwitcher = spriteSwitcher;
            _hitbox = hitbox;
            _health = health;
            _animation = animation;
            _definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IEnemySpriteSwitcher _spriteSwitcher;
        private readonly IHitbox _hitbox;
        private readonly IHealth _health;

        private readonly RespawnAnimation _animation;
        private readonly RespawnDefinition _definition;

        private CancellationTokenSource _cancellation;
        
        public EnemyStateDefinition Definition => _definition;
        
        public void OnEnabled()
        {
        }
        
        public void OnDisabled()
        {
            _spriteSwitcher.Disable();   
        }

        public async UniTask Enter()
        {
            _stateMachine.Enter(this);

            _cancellation = new CancellationTokenSource();
            _spriteSwitcher.Enable();   

            await _animator.PlayAsync(_animation, _cancellation.Token);

            _health.Restore();
            _hitbox.Enable();

            _stateMachine.Exit(this);
        }
        
        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}