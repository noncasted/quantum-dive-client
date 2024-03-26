using System.Threading;
using Animancer;
using Common.Tools.UniversalAnimators.Abstract;
using Common.Tools.UniversalAnimators.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.Animators.Abstract;

namespace GamePlay.Player.Entity.Views.Animators.Runtime
{
    public class PlayerAnimator : IPlayerAnimator
    {
        public PlayerAnimator(AnimancerComponent animator)
        {
            _animator = new EnhancedAnimator(animator);
        }

        private readonly IEnhancedAnimator _animator;
        
        public void PlayLooped(IAnimation animation)
        {
            _animator.PlayLooped(animation);
        }

        public async UniTask PlayAsync(IAnimation animation, CancellationToken cancellationToken)
        {
            await _animator.PlayAsync(animation, cancellationToken);
        }
    }
}