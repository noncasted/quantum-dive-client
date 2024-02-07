using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Services.List.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.List.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayersRegistryRoutes.ServiceName,
        menuName = PlayersRegistryRoutes.ServicePath)]
    public class PlayerListFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<PlayerList>()
                .As<IPlayerList>();
        }
    }
}