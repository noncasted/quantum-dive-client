﻿using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.Types.Range.States.Shoot.Common;
using GamePlay.Enemy.Entity.Types.Range.Views.ShootPoint;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using GamePlay.Services.Combat.Targets.Registry.Abstract;
using GamePlay.Services.Projectiles.Factory;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local
{
    public class LocalShoot : IShoot, IEnemyLocalState
    {
        public LocalShoot(
            ILocalStateMachine stateMachine,
            IEnemyAnimator animator,
            IProjectileFactory projectileFactory,
            IShootConfig shootConfig,
            IShootPoint shootPoint,
            ShootDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _projectileFactory = projectileFactory;
            _shootConfig = shootConfig;
            _shootPoint = shootPoint;
            _definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IProjectileFactory _projectileFactory;
        private readonly IShootConfig _shootConfig;
        private readonly IShootPoint _shootPoint;

        private readonly ShootDefinition _definition;

        private CancellationTokenSource _cancellation;

        public EnemyStateDefinition Definition => _definition;

        public async UniTask Shoot(ISearchableTarget target)
        {
            _stateMachine.Enter(this);

            _cancellation = new CancellationTokenSource();

            // var animationTask = _animator.PlayAsync(_animation, _cancellation.Token);
            // var shootEventTask = _animation.WaitShootFrameAsync(_cancellation.Token);
            //
            // await shootEventTask;

            var direction = (target.Position - _shootPoint.Point).normalized;

            var projectileRequest = new ProjectileRequest(
                    _shootConfig.Definition,
                    _shootPoint.Point, 
                    direction,
                    _shootConfig.Params);
            
            _projectileFactory.CreateLocalEnemy(projectileRequest);

            // await animationTask;
            
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