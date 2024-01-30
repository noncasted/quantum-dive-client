using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.DataTypes.Structs;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.States.Roll.Common;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Hitboxes.Local;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    public class LocalRoll : IEntitySwitchListener, IPlayerLocalState, IFloatingTransition
    {
        public LocalRoll(
            ILocalStateMachine stateMachine,
            ISubPush push,
            IRollConfig config,
            IPlayerAnimator playerAnimator,
            IPlayerSpriteFlip spriteFlip,
            IRollInput input,
            IFloatingTransitionsRegistry floatingTransitionsRegistry,
            IHitbox hitbox,
            RollAnimation animation,
            RollDefinition definition)
        {
            _stateMachine = stateMachine;
            _push = push;
            _config = config;
            _playerAnimator = playerAnimator;
            _spriteFlip = spriteFlip;
            _input = input;
            _floatingTransitionsRegistry = floatingTransitionsRegistry;
            _hitbox = hitbox;
            _animation = animation;
            _definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly ISubPush _push;
        private readonly IRollConfig _config;
        private readonly IPlayerAnimator _playerAnimator;
        private readonly IPlayerSpriteFlip _spriteFlip;
        private readonly IRollInput _input;
        private readonly IFloatingTransitionsRegistry _floatingTransitionsRegistry;
        private readonly IHitbox _hitbox;
        private readonly RollAnimation _animation;
        private readonly RollDefinition _definition;

        private CancellationTokenSource _cancellation;

        public PlayerStateDefinition Definition => _definition;

        public void OnEnabled()
        {
            _input.Performed += OnPerformed;

            _floatingTransitionsRegistry.Register(Definition, this);
        }

        public void OnDisabled()
        {
            _input.Performed -= OnPerformed;

            _floatingTransitionsRegistry.Unregister(Definition);
        }

        public bool IsTransitionFromFloatingAvailable()
        {
            return _input.HasInput;
        }

        public void EnterFromFloating()
        {
            if (_input.Direction == Vector2.zero)
                return;

            Begin().Forget();
        }

        private void OnPerformed()
        {
            if (_stateMachine.IsAvailable(Definition) == false)
                return;

            Begin().Forget();
        }

        public void Break()
        {
            _hitbox.Enable();

            Cancel();
        }

        private async UniTask Begin()
        {
            var payload = new RollPayload()
            {
                Direction = _input.Direction
            };

            _stateMachine.Enter(this, payload);

            _cancellation = new CancellationTokenSource();

            _hitbox.Disable();
            _spriteFlip.FlipAlong(_input.Direction, true);

            var orientation = _input.Direction.ToAngle().ToOrientation();
            _animation.SetOrientation(orientation);

            var animationTask = _playerAnimator.PlayAsync(_animation, _cancellation.Token);
            var pushTask = _push.PushAsync(_input.Direction, _config.Params, _cancellation.Token);

            await UniTask.WhenAll(animationTask, pushTask);

            _stateMachine.Exit(this);
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}