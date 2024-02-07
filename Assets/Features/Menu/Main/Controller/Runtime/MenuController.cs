using System;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.System.Network.Room.Lifecycle.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.Network.Session.Runtime.Create;
using Global.Network.Session.Runtime.Join;
using Global.System.MessageBrokers.Runtime;
using Menu.Main.UI.Runtime;
using Menu.Services.Network.Entity.Runtime;
using Menu.Services.Network.PlayersLists.Runtime;
using Menu.Services.Network.SceneCollectors.Runtime;

namespace Menu.Main.Controller.Runtime
{
    public class MenuController : IScopeSwitchListener
    {
        public MenuController(
            ISessionJoin join,
            ISessionCreate create,
            IMenuEntity menuEntity,
            IMenuView view,
            IPlayersList playersList,
            IClientProvider clientProvider,
            IRoomLifecycle roomLifecycle,
            IRoomProvider roomProvider,
            IMenuSceneCollector sceneCollector)
        {
            _join = join;
            _create = create;
            _menuEntity = menuEntity;
            _view = view;
            _playersList = playersList;
            _clientProvider = clientProvider;
            _roomLifecycle = roomLifecycle;
            _roomProvider = roomProvider;
            _sceneCollector = sceneCollector;
        }

        private readonly ISessionJoin _join;
        private readonly ISessionCreate _create;
        private readonly IMenuEntity _menuEntity;
        private readonly IMenuView _view;
        private readonly IPlayersList _playersList;
        private readonly IClientProvider _clientProvider;
        private readonly IRoomLifecycle _roomLifecycle;
        private readonly IRoomProvider _roomProvider;
        private readonly IMenuSceneCollector _sceneCollector;

        private IDisposable _createRequestListener;
        private IDisposable _joinRequestListener;
        private UniTaskCompletionSource _completion;

        public void OnEnabled()
        {
            _createRequestListener = Msg.Listen<CreateRequestEvent>(OnCreateRequested);
            _joinRequestListener = Msg.Listen<JoinRequestEvent>(OnJoinRequested);
        }

        public void OnDisabled()
        {
            _createRequestListener?.Dispose();
            _joinRequestListener?.Dispose();
        }

        private void OnCreateRequested(CreateRequestEvent request)
        {
            ProcessCreateRequest(request).Forget();
        }

        private async UniTaskVoid ProcessCreateRequest(CreateRequestEvent request)
        {
            _view.OnLoading();

            var idGenerator = new IdGenerator();
            var id = idGenerator.Create();
            _sceneCollector.Clear();
            _menuEntity.CreateEntity();
            var result = await _create.Create(id);

            switch (result.Type)
            {
                case SessionCreateResultType.Success:
                    var joinHandler = new JoinHandler(_playersList, _roomProvider, _clientProvider);
                    var joinTask =  joinHandler.ProcessJoin();

                    _roomLifecycle.SceneLoaded();

                    await joinTask;

                    Msg.Publish(new TransitLobbyRequestEvent());
                    break;
                case SessionCreateResultType.Fail:
                    request.OnError(result.ErrorMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _view.CancelLoading();
        }

        private void OnJoinRequested(JoinRequestEvent request)
        {
            ProcessJoinRequest(request).Forget();
        }

        private async UniTaskVoid ProcessJoinRequest(JoinRequestEvent request)
        {
            _view.OnLoading();

            _sceneCollector.Clear();
            _menuEntity.CreateEntity();

            var result = await _join.Join(request.RoomId);

            switch (result.Type)
            {
                case SessionJoinResultType.Success:
                    var joinHandler = new JoinHandler(_playersList, _roomProvider, _clientProvider);
                    var joinTask =  joinHandler.ProcessJoin();

                    _roomLifecycle.SceneLoaded();

                    await joinTask;
                    
                    Msg.Publish(new TransitLobbyRequestEvent());
                    break;
                case SessionJoinResultType.Fail:
                    request.OnError(result.ErrorMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            _view.CancelLoading();
        }
    }
}