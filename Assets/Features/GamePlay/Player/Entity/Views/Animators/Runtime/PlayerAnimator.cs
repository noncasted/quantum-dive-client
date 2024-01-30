using System.Threading;
using Common.Architecture.Entities.Runtime.Callbacks;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using Common.Tools.UniversalAnimators.Animators.Runtime;
using Common.Tools.UniversalAnimators.Updaters.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.Animators.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Animators.Runtime
{
    public class PlayerAnimator : IPlayerAnimator, IEntitySwitchListener
    {
        public PlayerAnimator(
            IAnimatorsUpdater animatorsUpdater,
            SpriteRenderer spriteRenderer,
            AnimatorLogger logger)
        {
            _animator = new UniversalAnimator(spriteRenderer);
            _animatorsUpdater = animatorsUpdater;
            _logger = logger;
        }

        private readonly IAnimatorsUpdater _animatorsUpdater;
        private readonly UniversalAnimator _animator;
        private readonly AnimatorLogger _logger;
        
        public void OnEnabled()
        {
            _animatorsUpdater.Register(_animator);
        }

        public void OnDisabled()
        {
            _animatorsUpdater.Unregister(_animator);
        }
        
        public void PlayLooped(ILoopedAnimation animation)
        {
            _logger.OnLooped(animation.Data.Name);
            _animator.PlayLooped(animation);
        }

        public async UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken)
        {
            _logger.OnAsync(animation.Data.Name);
            await _animator.PlayAsync(animation, cancellationToken);
        }
    }
}