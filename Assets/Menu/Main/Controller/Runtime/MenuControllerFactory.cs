using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Menu.Main.Controller.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.Controller.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuControllerRoutes.ServiceName, menuName = MenuControllerRoutes.ServicePath)]
    public class MenuControllerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<MenuController>()
                .AsCallbackListener();
        }
    }
}