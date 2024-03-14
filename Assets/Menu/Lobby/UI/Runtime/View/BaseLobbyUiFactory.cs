using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Lobby.UI.Runtime.View
{
    [InlineEditor]
    public abstract class BaseLobbyUiFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection services, IServiceScopeUtils utils);
    }
}