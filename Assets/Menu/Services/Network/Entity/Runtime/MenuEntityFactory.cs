using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Menu.Services.Network.Entity.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Services.Network.Entity.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuEntityRoutes.ServiceName,
        menuName = MenuEntityRoutes.ServicePath)]
    public class MenuEntityFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<MenuEntity>()
                .As<IMenuEntity>()
                .AsCallbackListener();
        }
    }
}