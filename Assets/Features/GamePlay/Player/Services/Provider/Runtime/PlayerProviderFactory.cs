using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Provider.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Provider.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerProviderRoutes.ServiceName,
        menuName = PlayerProviderRoutes.ServicePath)]
    public class PlayerProviderFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<PlayerProvider>()
                .As<IPlayerProvider>()
                .As<IPlayerPositionProvider>();
        }
    }
}