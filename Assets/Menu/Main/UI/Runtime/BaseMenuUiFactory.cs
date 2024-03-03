using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [InlineEditor]
    public abstract class BaseMenuUiFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection services, IScopeUtils utils);
    }
}