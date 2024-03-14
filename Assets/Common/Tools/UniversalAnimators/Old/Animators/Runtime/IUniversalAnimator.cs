using System.Threading;
using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Async;
using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Looped;
using Cysharp.Threading.Tasks;

namespace Common.Tools.UniversalAnimators.Old.Animators.Runtime
{
    public interface IUniversalAnimator
    {
        void PlayLooped(ILoopedAnimation animation);
        UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken);
    }
}