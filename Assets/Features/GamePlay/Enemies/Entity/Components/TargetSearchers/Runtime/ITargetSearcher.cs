using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemies.Entity.Components.TargetSearchers.Runtime
{
    public interface ITargetSearcher
    {
        UniTask<ISearchableTarget> SearchAsync(CancellationToken cancellation);
        bool IsTargetInSearchRange(ISearchableTarget target);
    }
}