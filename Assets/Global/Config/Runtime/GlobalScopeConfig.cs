﻿using System.Collections.Generic;
using Common.Architecture.Scopes.Common.DefaultCallbacks;
using Common.Architecture.Scopes.Common.DestroyHandler;
using Common.Architecture.Scopes.Runtime.Services;
using Global.Audio.Compose;
using Global.Backend.Runtime;
using Global.Cameras.Compose;
using Global.Configs.Compose;
using Global.Debugs.Drawing.Runtime;
using Global.GameLoops.Runtime;
using Global.Inputs.Compose;
using Global.Network.Compose;
using Global.Publisher.Abstract.Bootstrap;
using Global.System.Compose;
using Global.UI.Compose;
using Internal.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Global.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Global/Config")]
    public class GlobalScopeConfig : ScriptableObject, IScopeConfig
    {
        [SerializeField] private AudioCompose _audio;
        [SerializeField] private CameraCompose _camera;
        [SerializeField] private InputCompose _input;
        [SerializeField] private SystemCompose _system;
        [SerializeField] private GlobalNetworkCompose _network;
        [SerializeField] private GlobalUICompose _ui;
        [SerializeField] private GameLoopFactory _gameLoop;
        [SerializeField] private PublisherSdkFactory _publisherSdk;
        [SerializeField] private BackendFactory _backend;
        [SerializeField] private DefaultCallbacksServiceFactory _defaultCallbacks;
        [SerializeField] private ScopeDestroyHandlerFactory _scopeDestroyHandler;
        [SerializeField] private ConfigsCompose _configs;
        [SerializeField] private DrawingFactory _drawing;

        [SerializeField] private GlobalScope _scope;
        [SerializeField] private SceneData _servicesScene;
        [SerializeField] private bool _isMock;
        
        public LifetimeScope ScopePrefab => _scope;
        public ISceneAsset ServicesScene => _servicesScene;
        public bool IsMock => _isMock;
        public IReadOnlyList<IServiceFactory> Services => GetFactories();

        public IReadOnlyList<IServicesCompose> Composes => new IServicesCompose[]
        {
            _camera,
            _audio,
            _network,
            _input,
            _system,
            _ui,
            _configs
        };

        private IServiceFactory[] GetFactories() => new IServiceFactory[]
        {
            _publisherSdk,
            _gameLoop,
            _backend,
            _defaultCallbacks,
            _scopeDestroyHandler,
            _drawing
        };
    }
}