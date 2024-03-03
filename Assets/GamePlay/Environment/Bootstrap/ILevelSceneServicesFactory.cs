using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;

namespace GamePlay.Environment.Bootstrap
{
    public interface ILevelSceneServicesFactory
    {
        UniTask Create(IServiceCollection services, IScopeUtils utils);
    }
}