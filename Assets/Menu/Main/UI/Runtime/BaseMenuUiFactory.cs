using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [InlineEditor]
    public abstract class BaseMenuUiFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection services, IServiceScopeUtils utils);
    }
}