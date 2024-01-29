using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Idles.Common;
using GamePlay.Player.Entity.States.Idles.Logs;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.States.Idles.Local
{
    public class LocalIdle : IPlayerLocalState, IIdle, IUpdatable
    {
        public LocalIdle(
            ILocalStateMachine stateMachine,
            IPlayerAnimator animator,
            IPlayerSpriteFlip sprite,
            IRotation rotation,
            IUpdater updater,
            IdleDefinition definition,
            IdleLogger logger,
            IdleAnimation animation)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _sprite = sprite;
            _rotation = rotation;
            _updater = updater;
            Definition = definition;
            _logger = logger;
            _animation = animation;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IRotation _rotation;
        private readonly IUpdater _updater;

        private readonly IPlayerAnimator _animator;
        private readonly IPlayerSpriteFlip _sprite;

        private readonly IdleAnimation _animation;
        private readonly IdleLogger _logger;
        
        public PlayerStateDefinition Definition { get; }

        public void Enter()
        {
            _stateMachine.Enter(this);
            _animator.PlayLooped(_animation);
            _updater.Add(this);
            
            _logger.OnEntered();
        }

        public void Break()
        {
            _updater.Remove(this);

            _logger.OnBroke();
        }

        public void OnUpdate(float delta)
        {
            _animation.SetOrientation(_rotation.Orientation);
            _sprite.FlipAlong(_rotation.Angle);
        }
    }
}