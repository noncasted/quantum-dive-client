using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Loop.Runtime
{
    [InlineEditor]
    public abstract class BaseMenuLoopFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection services, IServiceScopeUtils utils);
    }
}