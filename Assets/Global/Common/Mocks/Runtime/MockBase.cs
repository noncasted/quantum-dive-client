using Cysharp.Threading.Tasks;
using Global.UI.LoadingScreens.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Setup.Runtime;
using UnityEngine;
using VContainer;

namespace Global.Common.Mocks.Runtime
{
    [DisallowMultipleComponent]
    public abstract class MockBase : MonoBehaviour
    {
        [SerializeField] private GlobalMockConfig _config;
        
        public abstract UniTaskVoid Process();
        
        protected async UniTask<MockBootstrapResult> BootstrapGlobal()
        {
            var internalScopeLoader = new InternalScopeLoader(_config.Internal);
            var internalScope = await internalScopeLoader.Load();
            var scopeLoaderFactory = internalScope.Container.Resolve<IServiceScopeLoader>();
            var scopeLoadResult = await scopeLoaderFactory.Load(internalScope, _config.Global);

            scopeLoadResult.Scope.Container.Resolve<ILoadingScreen>().HideGameLoading();

            await scopeLoadResult.Callbacks.RunConstruct();

            return new MockBootstrapResult(scopeLoadResult.Scope);
        }
    }
}