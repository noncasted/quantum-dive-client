using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Mocks.Runtime;
using Menu.Config.Runtime;
using UnityEngine;
using VContainer;

namespace Menu.Main.Mock
{
    [DisallowMultipleComponent]
    public class MenuGlobalMock : MockBase
    {
        [SerializeField] private MenuConfig _menu;
        [SerializeField] private GlobalMock _mock;
        
        public override async UniTaskVoid Process()
        {
            var result = await _mock.BootstrapGlobal();
            await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var resolver = result.Resolver;
            
            var scopeLoaderFactory = resolver.Resolve<IServiceScopeLoader>();
            var scopeLoader = await scopeLoaderFactory.Load(result.Parent, _menu);

            await result.RegisterLoadedScene(scopeLoader);
        }
    }
}