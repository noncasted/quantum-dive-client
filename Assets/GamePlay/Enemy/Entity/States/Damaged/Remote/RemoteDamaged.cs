﻿using System.Threading;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Damaged.Common;
using GamePlay.Enemy.Entity.States.Damaged.Vfx;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.States.Damaged.Remote
{
    public class RemoteDamaged : IEnemyRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteDamaged(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            IDamagedVfx vfx,
            DamagedDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _vfx = vfx;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IDamagedVfx _vfx;
        
        private readonly DamagedDefinition _definition;

        private CancellationTokenSource _cancellation;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }

        public void Enter(RagonBuffer buffer)
        {
            var angle = buffer.ReadFloat(0, 360, 1f);
            _vfx.Play(angle);
            _cancellation = new CancellationTokenSource();
            //_animator.PlayAsync(_animation, _cancellation.Token).Forget();
        }

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}