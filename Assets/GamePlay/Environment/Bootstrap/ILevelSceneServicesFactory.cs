using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

namespace GamePlay.Environment.Bootstrap
{
    public interface ILevelSceneServicesFactory
    {
        UniTask Create(IServiceCollection services, IServiceScopeUtils utils);
    }
}