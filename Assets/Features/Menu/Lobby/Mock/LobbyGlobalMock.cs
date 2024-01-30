using Common.Architecture.Mocks.Runtime;
using Common.Architecture.Scopes.Factory;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Lifecycle.Runtime;
using Global.Network.Connection.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.Network.Session.Runtime.Create;
using Global.Network.Session.Runtime.Join;
using Global.System.MessageBrokers.Runtime;
using Menu.Config.Runtime;
using Menu.Main.Controller.Runtime;
using Menu.Network.Entity.Runtime;
using Menu.Network.PlayersLists.Runtime;
using Menu.Network.SceneCollectors.Runtime;
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
            
            var scopeLoaderFactory = resolver.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(_menu, result.Parent);
            var scope = await scopeLoader.Load();

            await result.RegisterLoadedScene(scope);

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