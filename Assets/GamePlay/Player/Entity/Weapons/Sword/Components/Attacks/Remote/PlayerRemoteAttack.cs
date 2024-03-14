using System.Threading;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Remote.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Remote
{
    public class PlayerRemoteAttack : IPlayerRemoteState, IEntitySwitchLifetimeListener
    {
        public PlayerRemoteAttack(
            IRemoteRotation rotation,
            IUpdater updater,
            IRemoteStateMachine stateMachine,
            IEnhancedAnimator animator,
            SwordAttackDefinition definition)
        {
            _rotation = rotation;
            _updater = updater;
            _stateMachine = stateMachine;
            _animator = animator;
            _definition = definition;
        }

        private readonly IRemoteRotation _rotation;
        private readonly IUpdater _updater;
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IEnhancedAnimator _animator;
        private readonly SwordAttackDefinition _definition;

        private CancellationTokenSource _cancellation;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }

        public void Enter(RagonBuffer buffer)
        {
            // _cancellation = new CancellationTokenSource();
            // _updater.Add(this);
            // _animator.PlayAsync(_animation, _cancellation.Token).Forget();
        }

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}