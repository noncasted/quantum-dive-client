using Cysharp.Threading.Tasks;
using GamePlay.Services.System.Network.Room.Lifecycle.Abstract;
using Global.Network.Connection.Abstract;
using Global.Network.Handlers.ClientHandler.Abstract;
using Global.Network.Session.Abstract;
using Global.System.MessageBrokers.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Mocks.Runtime;
using Menu.Config.Runtime;
using Menu.Main.Controller.Runtime;
using Menu.Services.Network.Entity.Runtime;
using Menu.Services.Network.PlayersLists.Runtime;
using Menu.Services.Network.SceneCollectors.Runtime;
using UnityEngine;
using VContainer;
using JoinHandler = Menu.Main.Controller.Runtime.JoinHandler;

namespace Menu.Lobby.Mock
{
    [DisallowMultipleComponent]
    public class LobbyGlobalMock : MockBase
    {
        [SerializeField] private bool _isMaster;
        
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

            var connection = result.Resolver.Resolve<IConnection>();
            await connection.Connect($"Player_{Random.Range(0,100)}");

            var menuResolver = result.Resolver;

            var menuEntity = menuResolver.Resolve<IMenuEntity>();
            var playersList = menuResolver.Resolve<IPlayersList>();
            var clientProvider = menuResolver.Resolve<IClientProvider>();
            var sceneCollector = menuResolver.Resolve<IMenuSceneCollector>();
            var roomProvider = menuResolver.Resolve<IRoomProvider>();

            sceneCollector.Clear();
            menuEntity.CreateEntity();

            if (_isMaster == true)
            {
                var sessionCreate = result.Resolver.Resolve<ISessionCreate>();
                await sessionCreate.Create("1db7-6f88-431a-ae23");
            }
            else
            {
                var sessionJoin = result.Resolver.Resolve<ISessionJoin>();
                await sessionJoin.Join("1db7-6f88-431a-ae23");
            }

            var joinHandler = new JoinHandler(playersList, roomProvider, clientProvider);
            var joinTask = joinHandler.ProcessJoin();

            clientProvider.Client.Room.SceneLoaded();

            await joinTask;

            Msg.Publish(new TransitLobbyRequestEvent());
        }
    }
}