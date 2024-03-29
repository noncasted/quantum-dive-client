﻿using System.Threading;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.Types.Range.States.Shoot.Common;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Remote
{
    public class RemoteShoot : IEnemyRemoteState, IEntitySwitchLifetimeListener
    {
        public RemoteShoot(
            IRemoteStateMachine stateMachine,
            IEnemyAnimator animator,
            ShootDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _definition = definition;
        }

        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly ShootDefinition _definition;

        private CancellationTokenSource _cancellation;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }

        public void Enter(RagonBuffer buffer)
        {
            _cancellation = new CancellationTokenSource();
        }

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}