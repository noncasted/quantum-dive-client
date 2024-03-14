
using Internal.Scopes.Abstract.Lifetimes;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Runs.Remote
{
    public class RemoteRun : IPlayerRemoteState, IUpdatable, IEntitySwitchLifetimeListener
    {
        public RemoteRun(
            IUpdater updater,
            IRemoteStateMachine stateMachine,
            IEnhancedAnimator animator,
            IRunInputSync inputSync,
            IAnimation animation,
            RunDefinition definition)
        {
            _updater = updater;
            _stateMachine = stateMachine;
            _animator = animator;
            _inputSync = inputSync;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IUpdater _updater;
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnhancedAnimator _animator;
        private readonly IRunInputSync _inputSync;
        private readonly IAnimation _animation;
        private readonly RunDefinition _definition;
        
        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }
        
        public void Enter(RagonBuffer buffer)
        {
            _animator.PlayLooped(_animation);
            _updater.Add(this);
        }

        public void Break()
        {
            _updater.Remove(this);
        }

        public void OnUpdate(float delta)
        {
           // _animation.SetOrientation(_inputSync.Orientation);
        }
    }
}