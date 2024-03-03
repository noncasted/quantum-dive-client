using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<MenuEntity>()
                .As<IMenuEntity>()
                .AsCallbackListener();
        }
    }
}