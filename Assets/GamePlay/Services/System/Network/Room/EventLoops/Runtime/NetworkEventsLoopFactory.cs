using Cysharp.Threading.Tasks;
using GamePlay.Network.Common;
using GamePlay.Services.System.Network.Room.EventLoops.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GamePlayNetworkEvents", menuName = GamePlayNetworkRoutes.Root + "Events")]
    public class NetworkEventsLoopFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var callbacks = new NetworkCallbacksFactory();
            utils.Callbacks.AddCustomListener(callbacks);

            services.RegisterInstance(callbacks)
                .AsSelf()
                .As<IGamePlayNetworkCallbacks>();

            services.Inject(callbacks);
        }
    }
}