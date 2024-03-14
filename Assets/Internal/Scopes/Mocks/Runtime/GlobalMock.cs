using System;
using Cysharp.Threading.Tasks;
using Global.UI.LoadingScreens.Abstract;
using Internal.Runtime;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;
using VContainer;

namespace Internal.Scopes.Mocks.Runtime
{
    [Serializable]
    public class GlobalMock
    {
        [SerializeField] private GlobalMockConfig _config;

        public async UniTask<MockBootstrapResult> BootstrapGlobal()
        {
            var internalScopeLoader = new InternalScopeLoader(_config.Internal);
            var internalScope = await internalScopeLoader.Load();
            var scopeLoaderFactory = internalScope.Container.Resolve<IServiceScopeLoader>();
            var scopeLoadResult = await scopeLoaderFactory.Load(internalScope, _config.Global);

            scopeLoadResult.Scope.Container.Resolve<ILoadingScreen>().HideGameLoading();

            return new MockBootstrapResult(scopeLoadResult.Scope);
        }
    }
}