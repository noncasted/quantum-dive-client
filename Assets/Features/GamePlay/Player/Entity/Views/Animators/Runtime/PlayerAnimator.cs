using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using Common.Tools.UniversalAnimators.Animators.Native;
using Common.Tools.UniversalAnimators.Animators.Runtime;
using Common.Tools.UniversalAnimators.Updaters.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.Animators.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Animators.Runtime
{
    public class PlayerAnimator : IPlayerAnimator
    {
        public PlayerAnimator(
            IAnimatorsUpdater animatorsUpdater,
            Animator animator,
            AnimatorLogger logger)
        {
            _animator = new NativeAnimator(animator);
            _animatorsUpdater = animatorsUpdater;
            _logger = logger;
        }

        private readonly IAnimatorsUpdater _animatorsUpdater;
        private readonly IUniversalAnimator _animator;
        private readonly AnimatorLogger _logger;
        
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