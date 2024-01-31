using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Entities.Common.DefaultCallbacks
{
    public interface IEntityCallbacks
    {
        UniTask RunConstruct();
        UniTask RunEnable(ILifetime lifetime);
        UniTask RunDisable();
        UniTask RunDispose();
    }
}