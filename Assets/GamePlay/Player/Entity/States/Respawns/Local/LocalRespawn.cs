﻿using System.Threading;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Locker.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Respawns.Common;
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
            RespawnDefinition definition)
        {
            _stateMachine = stateMachine;
            _playerAnimator = playerAnimator;
            _locker = locker;
            _hitbox = hitbox;
            _animation = animation;
            Definition = definition;
        }

        private readonly IEnhancedAnimator _playerAnimator;

        private readonly IEquipmentLocker _locker;
        private readonly IHitbox _hitbox;
        private readonly ILocalStateMachine _stateMachine;
        
        private readonly IAnimation _animation;

        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition { get; }
        
        public void Enter()
        {
            _locker.Lock();
            _stateMachine.Enter(this);

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