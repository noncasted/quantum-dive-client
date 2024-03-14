using System.Threading;
using Animancer;
using Common.Tools.UniversalAnimators.Abstract;
using Common.Tools.UniversalAnimators.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.Animators.Abstract;
using GamePlay.Player.Entity.Views.Animators.Logs;

namespace GamePlay.Player.Entity.Views.Animators.Runtime
{
    public class PlayerAnimator : IPlayerAnimator
    {
        public PlayerAnimator(
            AnimancerComponent animator,
            AnimatorLogger logger)
        {
            _animator = new EnhancedAnimator(animator);
            _logger = logger;
        }

        private readonly IEnhancedAnimator _animator;
        private readonly AnimatorLogger _logger;
        
        public void PlayLooped(IAnimation animation)
        {
            _logger.OnLooped(animation.Data.Clip.name);
            _animator.PlayLooped(animation);
        }

        public async UniTask PlayAsync(IAnimation animation, CancellationToken cancellationToken)
        {
            _logger.OnAsync(animation.Data.Clip.name);
            await _animator.PlayAsync(animation, cancellationToken);
        }
    }
}