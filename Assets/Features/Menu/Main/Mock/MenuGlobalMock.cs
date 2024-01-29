using Common.Architecture.Mocks.Runtime;
using Common.Architecture.Scopes.Factory;
using Cysharp.Threading.Tasks;
using Global.Config.Runtime;
using Global.GameLoops.Runtime;
using Menu.Config.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

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
            
            var scopeLoaderFactory = resolver.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(_menu, result.Parent);
            var scope = await scopeLoader.Load();

            await result.RegisterLoadedScene(scope);
        }
    }
}