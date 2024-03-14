using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Idles.Common;
using GamePlay.Player.Entity.States.Idles.Logs;
using Global.System.Updaters.Abstract;

namespace GamePlay.Player.Entity.States.Idles.Local
{
    public class LocalIdle : IPlayerLocalState, IIdle, IUpdatable
    {
        public LocalIdle(
            ILocalStateMachine stateMachine,
            IEnhancedAnimator animator,
            IRotation rotation,
            IUpdater updater,
            IdleDefinition definition,
            IdleLogger logger,
            IAnimation animation)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _rotation = rotation;
            _updater = updater;
            Definition = definition;
            _logger = logger;
            _animation = animation;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IRotation _rotation;
        private readonly IUpdater _updater;

        private readonly IEnhancedAnimator _animator;

        private readonly IAnimation _animation;
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
            //_animation.SetOrientation(_rotation.Orientation);
        }
    }
}