using System.Threading;
using Common.DataTypes.Structs;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Damaged.Common;
using GamePlay.Enemy.Entity.States.Damaged.Vfx;
using GamePlay.Enemy.Entity.States.SubStates.Pushes.Abstract;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using GamePlay.Enemy.Entity.Views.RigidBodies.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Damaged.Local
{
    public class LocalDamaged : IEntitySwitchLifetimeListener, IDamaged, IEnemyLocalState
    {
        public LocalDamaged(
            ILocalStateMachine localStateMachine,
            IRemoteStateMachine remoteStateMachine,
            IEnemyAnimator animator,
            IEnemyRigidBody rigidBody,
            IPushConfig pushConfig,
            ISubPush subPush,
            IDamagedVfx vfx,
            DamagedAnimation animation,
            DamagedDefinition definition)
        {
            _localStateMachine = localStateMachine;
            _remoteStateMachine = remoteStateMachine;
            _animator = animator;
            _rigidBody = rigidBody;
            _pushConfig = pushConfig;
            _subPush = subPush;
            _vfx = vfx;
            _animation = animation;
            _definition = definition;
        }

        private readonly ILocalStateMachine _localStateMachine;
        private readonly IRemoteStateMachine _remoteStateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IEnemyRigidBody _rigidBody;

        private readonly IPushConfig _pushConfig;
        private readonly ISubPush _subPush;
        private readonly IDamagedVfx _vfx;

        private readonly DamagedAnimation _animation;
        private readonly DamagedDefinition _definition;

        private CancellationTokenSource _cancellation;

        public EnemyStateDefinition Definition => _definition;


        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _remoteStateMachine.RegisterFlush(lifetime, _definition, new PayloadFlush());
        }

        public async UniTask Enter(Vector2 damageDirection, float pushForce)
        {
            var angle = damageDirection.ToAngle();

            var payload = new DamagedPayload
            {
                Angle = angle
            };

            _localStateMachine.Enter(this, payload);

            _rigidBody.Enable();
            _cancellation = new CancellationTokenSource();

            _vfx.Play(angle);

            var animationTask = _animator.PlayAsync(_animation, _cancellation.Token);

            var distance = _pushConfig.BaseDistance * pushForce;
            var pushParams = new PushParams(_pushConfig.Time, distance, _pushConfig.Curve);
            var pushTask = _subPush.PushAsync(damageDirection, pushParams, _cancellation.Token);

            await UniTask.WhenAll(animationTask, pushTask);

            _localStateMachine.Exit(this);
        }

        public void Break()
        {
            _rigidBody.Disable();

            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}