using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.Views.Animators.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common;
using Global.System.Updaters.Runtime.Abstract;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Remote
{
    public class PlayerRemoteAttack : IPlayerRemoteState, IUpdatable, IEntitySwitchLifetimeListener
    {
        public PlayerRemoteAttack(
            IRemoteRotation rotation,
            IUpdater updater,
            IRemoteStateMachine stateMachine,
            IPlayerSpriteFlip spriteFlip,
            IPlayerAnimator animator,
            SwordAttackAnimation animation,
            SwordAttackDefinition definition)
        {
            _rotation = rotation;
            _updater = updater;
            _stateMachine = stateMachine;
            _spriteFlip = spriteFlip;
            _animator = animator;
            _animation = animation;
            _definition = definition;
        }
        
        private readonly IRemoteRotation _rotation;
        private readonly IUpdater _updater;
        private readonly IRemoteStateMachine _stateMachine;
        private readonly IPlayerSpriteFlip _spriteFlip;
        private readonly IPlayerAnimator _animator;
        private readonly SwordAttackAnimation _animation;
        private readonly SwordAttackDefinition _definition;

        private CancellationTokenSource _cancellation;
        
        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.RegisterState(lifetime, _definition, this);
        }
        
        public void Enter(RagonBuffer buffer)
        {
            _cancellation = new CancellationTokenSource();
            _updater.Add(this);
            _animator.PlayAsync(_animation, _cancellation.Token).Forget();
        }

        public void Break()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
            
            _updater.Remove(this);
        }

        public void OnUpdate(float delta)
        {
            _animation.SetOrientation(_rotation.Orientation);
            _spriteFlip.FlipAlong(_rotation.Angle);
        }
    }
}