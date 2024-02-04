using System.Threading;
using Common.DataTypes.Structs;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Entity.States.Damaged.Common;
using GamePlay.Enemies.Entity.States.Damaged.Vfx;
using GamePlay.Enemies.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Enemies.Entity.Views.Animators.Runtime;
using GamePlay.Enemies.Entity.Views.RigidBodies.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Damaged.Local
{
    public class LocalDamaged : IEntitySwitchListener, IDamaged, IEnemyLocalState
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

        public void OnEnabled()
        {
            _remoteStateMachine.RegisterFlush(_definition, new PayloadFlush());
        }

        public void OnDisabled()
        {
            _remoteStateMachine.UnregisterFlush(_definition);
        }

        public async UniTask Enter(Vector2 damageDirection, float pushForce)
        {
            var angle = damageDirection.ToAngle();
            
            var payload = new DamagedPayload()
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