using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Menu.Network.Entity.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Network.Entity.Runtime
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