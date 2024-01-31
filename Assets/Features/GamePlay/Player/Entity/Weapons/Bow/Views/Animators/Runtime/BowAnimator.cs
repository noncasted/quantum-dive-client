using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using Common.Tools.UniversalAnimators.Animators.Runtime;
using Common.Tools.UniversalAnimators.Updaters.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime
{
    public class BowAnimator : IBowAnimator, IEntitySwitchLifetimeListener
    {
        public BowAnimator(SpriteRenderer spriteRenderer, IAnimatorsUpdater updater)
        {
            _updater = updater;
            _animator = new UniversalAnimator(spriteRenderer);
        }

        private readonly IAnimatorsUpdater _updater;
        private readonly UniversalAnimator _animator;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Register(lifetime, _animator);
        }
        
        public void PlayLooped(ILoopedAnimation animation)
        {
            _animator.PlayLooped(animation);
        }

        public async UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken)
        {
            await _animator.PlayAsync(animation, cancellationToken);
        }
    }
}