using System.Threading;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Locker.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Respawns.Common;
using GamePlay.Player.Entity.States.Respawns.Logs;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Hitboxes.Local;

namespace GamePlay.Player.Entity.States.Respawns.Local
{
    public class LocalRespawn : IPlayerLocalState, IRespawn
    {
        public LocalRespawn(
            ILocalStateMachine stateMachine,
            IEnhancedAnimator playerAnimator,
            IEquipmentLocker locker,
            IHitbox hitbox,
            IAnimation animation,
            RespawnLogger logger,
            RespawnDefinition definition)
        {
            _stateMachine = stateMachine;
            _playerAnimator = playerAnimator;
            _locker = locker;
            _hitbox = hitbox;
            _animation = animation;
            _logger = logger;
            Definition = definition;
        }

        private readonly IEnhancedAnimator _playerAnimator;

        private readonly IEquipmentLocker _locker;
        private readonly IHitbox _hitbox;
        private readonly ILocalStateMachine _stateMachine;
        
        private readonly IAnimation _animation;
        private readonly RespawnLogger _logger;

        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition { get; }
        
        public void Enter()
        {
            _locker.Lock();
            _stateMachine.Enter(this);

            _logger.OnEntered();

            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;

            Process().Forget();
        }

        public void Break()
        {
            _locker.Unlock();
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;

            _logger.OnBroke();
        }

        private async UniTask Process()
        {
            _cancellation = new CancellationTokenSource();
            await _playerAnimator.PlayAsync(_animation, _cancellation.Token);

            _hitbox.Enable();

            _stateMachine.Exit(this);
        }
    }
}