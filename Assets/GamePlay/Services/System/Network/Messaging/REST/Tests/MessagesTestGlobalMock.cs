using System.Collections.Generic;
using Common.Architecture.Scopes.Common.DefaultCallbacks;
using Common.Architecture.Scopes.Factory;
using Common.Architecture.Scopes.Runtime.Services;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Scope;
using GamePlay.System.Network.Compose;
using Global.Network.Connection.Runtime;
using Global.Network.Session.Runtime.Create;
using Global.Network.Session.Runtime.Join;
using Internal.Scenes.Data;
using Internal.Scopes.Mocks.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GamePlay.System.Network.Messaging.REST.Tests
{
    public class MessagesTestGlobalMock : MockBase, IScopeConfig
    {
        [SerializeField] private GlobalMock _global;
        [SerializeField] private LevelNetworkCompose _network;

        [SerializeField] private GamePlayScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;
        [SerializeField] private DefaultCallbacksServiceFactory _serviceDefaultCallbacks;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;
        public bool IsMock => false;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _serviceDefaultCallbacks
        };

        public IReadOnlyList<IServicesCompose> Composes => new IServicesCompose[]
        {
            _network
        };

        public override async UniTaskVoid Process()
        {
            var result = await _global.BootstrapGlobal();
            var resolver = result.Resolver;

            var connection = resolver.Resolve<IConnection>();
            await connection.Connect("player");

            var sessionName = "message-test";

            var sessionJoin = resolver.Resolve<ISessionJoin>();
            var joinResult = await sessionJoin.Join(sessionName);

            if (joinResult.Type == SessionJoinResultType.Fail)
            {
                var sessionCreate = resolver.Resolve<ISessionCreate>();
                await sessionCreate.Create("room");
            }

            var scopeLoaderFactory = resolver.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(this, result.Parent);
            var scope = await scopeLoader.Load();

            await result.RegisterLoadedScene(scope);
        }
    }
}