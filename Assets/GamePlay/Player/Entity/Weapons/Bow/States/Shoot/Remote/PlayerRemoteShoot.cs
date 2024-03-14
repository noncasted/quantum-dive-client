using System.Threading;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Remote
{
    public class PlayerRemoteShoot : IEntitySwitchLifetimeListener, IPlayerRemoteState
    {
        public PlayerRemoteShoot(
            IRemoteStateMachine stateMachine,
            IRemoteRotation remoteRotation,
            IPlayerAnimator playerAnimator,
            IBowAnimator bowAnimator,
            IBowGameObject bowGameObject,
            IUpdater updater,
            
            BowShootDefinition definition)
        {
            _stateMachine = stateMachine;
            _remoteRotation = remoteRotation;
            _playerAnimator = playerAnimator;
            _bowAnimator = bowAnimator;
            _bowGameObject = bowGameObject;
            _updater = updater;
            
            _definition = definition;
        }
        
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IRemoteRotation _remoteRotation;
        private readonly IEnhancedAnimator _playerAnimator;
        private readonly IBowAnimator _bowAnimator;
        private readonly IBowGameObject _bowGameObject;
        private readonly IUpdater _updater;
        
        private readonly BowShootDefinition _definition;

        private CancellationTokenSource _cancellation;
        
        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);

        }

        public void Enter(RagonBuffer buffer)
        {
            _cancellation = new CancellationTokenSource();
            _bowGameObject.Enable();
        }

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
            
        }
    }
}