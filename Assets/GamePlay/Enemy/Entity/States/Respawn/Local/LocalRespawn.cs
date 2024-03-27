using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.Healths.Abstract;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Respawn.Common;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using GamePlay.Enemy.Entity.Views.Hitbox.Local;
using GamePlay.Enemy.Entity.Views.Sprites.Abstract;
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
            RespawnDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _spriteSwitcher = spriteSwitcher;
            _hitbox = hitbox;
            _health = health;
            _definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IEnemySpriteSwitcher _spriteSwitcher;
        private readonly IHitbox _hitbox;
        private readonly IHealth _health;

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