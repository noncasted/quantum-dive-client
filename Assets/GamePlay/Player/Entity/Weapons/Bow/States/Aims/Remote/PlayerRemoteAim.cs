﻿using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common.Animations;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Remote
{
    public class PlayerRemoteAim : IEntitySwitchLifetimeListener, IPlayerRemoteState, IUpdatable
    {
        public PlayerRemoteAim(
            IRemoteStateMachine stateMachine,
            IRemoteRotation remoteRotation,
            IEnhancedAnimator playerAnimator,
            IBowAnimator bowAnimator,
            IBowGameObject bowGameObject,
            IBowArrow arrow,
            IProjectileStarterConfig config,
            IUpdater updater,
            PlayerAimAnimation playerAnimation,
            BowAimAnimation bowAnimation,
            AimDefinition definition)
        {
            _stateMachine = stateMachine;
            _remoteRotation = remoteRotation;
            _playerAnimator = playerAnimator;
            _bowAnimator = bowAnimator;
            _bowGameObject = bowGameObject;
            _arrow = arrow;
            _config = config;
            _updater = updater;
            _playerAnimation = playerAnimation;
            _bowAnimation = bowAnimation;
            _definition = definition;
        }
        
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IRemoteRotation _remoteRotation;
        private readonly IEnhancedAnimator _playerAnimator;
        private readonly IBowAnimator _bowAnimator;
        private readonly IBowGameObject _bowGameObject;
        private readonly IBowArrow _arrow;
        private readonly IProjectileStarterConfig _config;
        private readonly IUpdater _updater;
        private readonly PlayerAimAnimation _playerAnimation;
        private readonly BowAimAnimation _bowAnimation;
        private readonly AimDefinition _definition;

        private CancellationTokenSource _cancellation;
        
        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }

        public void Enter(RagonBuffer buffer)
        {
            _cancellation = new CancellationTokenSource();
            _updater.Add(this);
            _bowGameObject.Enable();
            _arrow.Show(_config.Data.Preview);

            Process().Forget();
        }

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
            
            _updater.Remove(this);
            _bowGameObject.Disable();
            _arrow.Hide();
        }

        
        public void OnUpdate(float delta)
        {
            _playerAnimation.SetOrientation(_remoteRotation.Orientation);
        }
        
        private async UniTaskVoid Process()
        {
            // var playerAnimationTask = _playerAnimator.PlayAsync(_playerAnimation, _cancellation.Token);
            // var bowAnimationTask = _bowAnimator.PlayAsync(_bowAnimation, _cancellation.Token);
            //
            // await UniTask.WhenAll(tasks: new[] { playerAnimationTask, bowAnimationTask });
        }
    }
}