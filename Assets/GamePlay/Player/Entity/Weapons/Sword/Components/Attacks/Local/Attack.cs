﻿using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.DataTypes.Structs;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Damages;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common;
using GamePlay.Player.Entity.Weapons.Sword.Components.Input.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Local
{
    public class Attack :
        IPlayerLocalState,
        IFloatingTransition,
        IEntitySwitchLifetimeListener,
        IUpdatable
    {
        public Attack(
            IInputReceiver inputReceiver,
            ITargetsSearcher targetsSearcher,
            IEnhancedAnimator animator,
            IUpdater updater,
            IRotation rotation,
            IAttackArea attackArea,
            ILocalStateMachine stateMachine,
            ISubPush subPush,
            ISwordAttackConfig config,
            IPlayerPosition position,
            PushParams pushParams,
            SwordAttackAnimation animation,
            SwordAttackDefinition definition)
        {
            _animation = animation;
            _inputReceiver = inputReceiver;
            _targetsSearcher = targetsSearcher;
            _animator = animator;
            _updater = updater;
            _rotation = rotation;
            _stateMachine = stateMachine;
            _config = config;
            _position = position;
            _pushParams = pushParams;

            

            Definition = definition;
        }

        private readonly IInputReceiver _inputReceiver;
        private readonly ITargetsSearcher _targetsSearcher;
        private readonly IEnhancedAnimator _animator;
        private readonly IUpdater _updater;
        private readonly IRotation _rotation;
        private readonly IAttackArea _attackArea;
        private readonly ILocalStateMachine _stateMachine;
        private readonly ISwordAttackConfig _config;
        private readonly IPlayerPosition _position;
        private readonly PushParams _pushParams;
        private readonly SwordAttackAnimation _animation;

        private bool _isEntered;
        private PlayerOrientation _orientation;
        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition { get; }

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
            lifetime.ListenTerminate(OnLifetimeTerminated);
        }

        public void Break()
        {
            _isEntered = false;
            Cancel();
        }

        public bool IsTransitionFromFloatingAvailable()
        {
            if (_inputReceiver.IsPerformed == false)
                return false;

            if (_isEntered == true)
                return false;

            return true;
        }

        public void EnterFromFloating()
        {
            Process().Forget();
        }

        public void OnUpdate(float delta)
        {
            if (IsTransitionFromFloatingAvailable() == true && _stateMachine.IsAvailable(Definition))
                Process().Forget();

            if (_isEntered == false)
                return;

            _animation.SetOrientation(_orientation);
        }

        private async UniTask Process()
        {
            _stateMachine.Enter(this);
            _cancellation = new CancellationTokenSource();
            _isEntered = true;
            
            _orientation = _rotation.Orientation;
            
            _animation.Attack += OnAttackFrame;
            //
            // var animationTask = _animator.PlayAsync(_animation, _cancellation.Token);
            //
            // await UniTask.WhenAll(animationTask);

            _animation.Attack -= OnAttackFrame;

            _isEntered = false;
            _stateMachine.Exit(this);
        }

        private void OnAttackFrame()
        {
            var angle = _rotation.Angle;
            var damageReceivers = _attackArea.GetDamageReceivers(angle);

            foreach (var damageReceiver in damageReceivers)
            {
                var direction = (damageReceiver.Position - _position.Position).normalized;
                var damage = new Damage(_config.Damage, _config.PushForce, direction);
                damageReceiver.ReceiveDamage(damage);
            }
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
        
        private void OnLifetimeTerminated()
        {
            if (_isEntered == true)
            {
                _stateMachine.Exit(this);

                Break();
            }

            _isEntered = false;
        }
    }
}