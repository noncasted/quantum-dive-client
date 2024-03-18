using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Services.System.Network.Room.EventLoops.Abstract;
using Global.Network.Handlers.ClientHandler.Abstract;
using Internal.Scopes.Abstract.Callbacks;
using Internal.Scopes.Runtime.Callbacks;
using Ragon.Client;
using VContainer;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    public class NetworkCallbacksFactory : ICallbacksListener, IGamePlayNetworkCallbacks
    {
        [Inject]
        private void Construct(IClientProvider clientProvider, ISceneEntityFactory sceneEntityFactory)
        {
            _sceneEntityFactory = sceneEntityFactory;
            _clientProvider = clientProvider;
        }

        public NetworkCallbacksFactory()
        {
            _awake.Add(new CallbackEntity<INetworkAwakeListener>(
                listener => listener.OnNetworkAwake(), 0));
            _sceneEntityCreation.Add(
                new AsyncCallbackEntity<INetworkSceneEntityCreationListener>(CreateSceneEntities, 0));
            _destroy.Add(
                new AsyncCallbackEntity<INetworkDestroyListener>(listener => listener.OnNetworkDestroy(), 0));
        }

        private readonly ICallbacksStage _awake = new CallbacksHandler();
        private readonly ICallbacksStage _callbacksRegistration = new CallbacksHandler();
        private readonly ICallbacksStage _sceneEntityCreation = new CallbacksHandler();
        private readonly ICallbacksStage _destroy = new CallbacksHandler();

        private IClientProvider _clientProvider;
        private ISceneEntityFactory _sceneEntityFactory;

        public void Listen(object listener)
        {
            _awake.Listen(listener);
            _callbacksRegistration.Listen(listener);
            _sceneEntityCreation.Listen(listener);
            _destroy.Listen(listener);
        }

        public async UniTask InvokeRegisterCallbacks(RagonEventCache events)
        {
            await _callbacksRegistration.Run();
        }

        public async UniTask InvokeSceneEntityCreation()
        {
            await _sceneEntityCreation.Run();
        }

        public async UniTask InvokeAwakeCallbacks()
        {
            await _awake.Run();
        }

        public async UniTask InvokeDestroyCallbacks()
        {
            await _destroy.Run();
        }

        private UniTask CreateSceneEntities(INetworkSceneEntityCreationListener listener)
        {
            return listener.OnSceneEntityCreation(_sceneEntityFactory);
        }
    }
}