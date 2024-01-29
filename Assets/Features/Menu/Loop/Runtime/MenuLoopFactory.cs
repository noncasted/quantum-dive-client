using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Loop.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuLoopRoutes.ServiceName,
        menuName = MenuLoopRoutes.ServicePath)]
    public class MenuLoopFactory : BaseMenuLoopFactory
    {
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<MenuLoop>()
                .AsCallbackListener();
        }
    }
}