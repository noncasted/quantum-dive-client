using Internal.Scopes.Abstract.Containers;

using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Instances.Services;
using Menu.Loop.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuLoopRoutes.MockServiceName,
        menuName = MenuLoopRoutes.MockServicePath)]
    public class MockMenuLoopFactory : BaseMenuLoopFactory
    {
        public override async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<MockMenuLoop>()
                .AsCallbackListener();
        }
    }
}