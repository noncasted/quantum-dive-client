using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Main.Controller.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.Controller.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuControllerRoutes.ServiceName, menuName = MenuControllerRoutes.ServicePath)]
    public class MenuControllerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<MenuController>()
                .AsCallbackListener();
        }
    }
}