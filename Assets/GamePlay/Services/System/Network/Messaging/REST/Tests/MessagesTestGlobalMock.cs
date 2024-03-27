using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Services.Common.Scope;
using GamePlay.Services.Network.Compose;
using Global.Common.Mocks.Runtime;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using Internal.Scopes.Common.Services;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Services.Network.Messaging.REST.Tests
{
    public class MessagesTestGlobalMock : MockBase, IServiceScopeConfig
    {
        [SerializeField] private LevelNetworkCompose _network;

        [SerializeField] private GamePlayScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;
        [SerializeField] private ServiceDefaultCallbacksFactory _serviceDefaultCallbacks;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public SceneData ServicesScene => _servicesScene;
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
            // var result = await _global.BootstrapGlobal();
            // var resolver = result.Resolver;
            //
            // var connection = resolver.Resolve<IConnection>();
            // await connection.Connect("player");
            //
            // var sessionName = "message-test";
            //
            // var sessionJoin = resolver.Resolve<ISessionJoin>();
            // var joinResult = await sessionJoin.Join(sessionName);
            //
            // if (joinResult.Type == SessionJoinResultType.Fail)
            // {
            //     var sessionCreate = resolver.Resolve<ISessionCreate>();
            //     await sessionCreate.Create("room");
            // }
            //
            // var scopeLoaderFactory = resolver.Resolve<IServiceScopeLoader>();
            // var scope = await scopeLoaderFactory.Load(result.Parent, this);
            //
            // await result.RegisterLoadedScene(scope);
        }
    }
}