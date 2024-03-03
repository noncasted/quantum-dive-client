using System.Threading;
using Animancer;
using Common.Tools.UniversalAnimators.Abstract;
using Common.Tools.UniversalAnimators.Runtime;
using Cysharp.Threading.Tasks;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime
{
    public class BowAnimator : IBowAnimator
    {
        public BowAnimator(AnimancerComponent animator)
        {
            _animator = new EnhancedAnimator(animator);
        }

        private readonly IEnhancedAnimator _animator;

        public void PlayLooped(IAnimation animation)
        {
            _animator.PlayLooped(animation);
        }

        public UniTask PlayAsync(IAnimation animation, CancellationToken cancellationToken)
        {
            return _animator.PlayAsync(animation, cancellationToken);
        }
    }
}