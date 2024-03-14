using System.Threading;
using Common.Tools.UniversalAnimators.Old.Animations.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Tools.UniversalAnimators.Old.Animations.Implementations.Async
{
    public interface IAsyncAnimation : IUpdatableAnimation
    {
        AnimationData Data { get; }

        UniTask Play(CancellationToken cancellationToken);
    }
}