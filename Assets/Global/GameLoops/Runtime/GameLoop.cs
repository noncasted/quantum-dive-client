﻿using Cysharp.Threading.Tasks;
using GamePlay.Common.Config.Runtime;
using Global.Cameras.CurrentProvider.Abstract;
using Global.Cameras.Persistent.Abstract;
using Global.Network.Connection.Abstract;
using Global.System.ScopeDisposer.Abstract;
using Global.UI.LoadingScreens.Abstract;
using Global.UI.Overlays.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using VContainer.Unity;

namespace Global.GameLoops.Runtime
{
    public class GameLoop : IScopeLoadAsyncListener
    {
        public GameLoop(
            LifetimeScope scope,
            IServiceScopeLoader scopeLoaderFactory,
            ILoadingScreen loadingScreen,
            IGlobalCamera globalCamera,
            IScopeDisposer scopeDisposer,
            ICurrentCameraProvider currentCameraProvider,
            IConnection connection,
            IGlobalExceptionController globalException,
            LevelConfig levelScope)
        {
            _scope = scope;
            _scopeLoaderFactory = scopeLoaderFactory;
            _loadingScreen = loadingScreen;
            _globalCamera = globalCamera;
            _scopeDisposer = scopeDisposer;
            _currentCameraProvider = currentCameraProvider;
            _connection = connection;
            _globalException = globalException;
            _levelScope = levelScope;
        }

        private readonly ICurrentCameraProvider _currentCameraProvider;
        private readonly IConnection _connection;
        private readonly IGlobalExceptionController _globalException;
        private readonly LevelConfig _levelScope;
        private readonly IScopeDisposer _scopeDisposer;
        private readonly IGlobalCamera _globalCamera;

        private readonly ISceneLoader _loader;
        private readonly ILoadingScreen _loadingScreen;

        private readonly LifetimeScope _scope;
        private readonly IServiceScopeLoader _scopeLoaderFactory;

        private IServiceScopeLoadResult _currentScope;

        public async UniTask OnLoadedAsync()
        {
            ProcessGameStart().Forget();
        }

        private async UniTask ProcessGameStart()
        {
            var connectionResult = await _connection.Connect("player");

            if (connectionResult == ConnectionResultType.Fail)
            {
                _globalException.Show();
                return;
            }

            await LoadScene(_levelScope);
            _loadingScreen.HideGameLoading();
        }

        private async UniTask LoadScene(IServiceScopeConfig config)
        {
            _globalCamera.Enable();
            _currentCameraProvider.SetCamera(_globalCamera.Camera);

            var unloadTask = UniTask.CompletedTask;

            if (_currentScope != null)
                unloadTask = _scopeDisposer.Unload(_currentScope);

            var scopeLoader = await _scopeLoaderFactory.Load(_scope, config);
            _currentScope = scopeLoader;
            await unloadTask;
            await scopeLoader.Callbacks.RunConstruct();
        }
    }
}