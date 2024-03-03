using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Loop.Runtime
{
    [InlineEditor]
    public abstract class BaseMenuLoopFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection services, IScopeUtils utils);
    }
}