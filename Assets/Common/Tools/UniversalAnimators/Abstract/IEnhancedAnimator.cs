using System.Threading;
using Cysharp.Threading.Tasks;

namespace Common.Tools.UniversalAnimators.Abstract
{
    public interface IEnhancedAnimator
    {
        void PlayLooped(IAnimation animation);
        UniTask PlayAsync(IAnimation animation, CancellationToken cancellationToken);
    }
}