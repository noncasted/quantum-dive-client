using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using GamePlay.Player.List.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.List.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayersRegistryRoutes.ServiceName,
        menuName = PlayersRegistryRoutes.ServicePath)]
    public class PlayerListFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<PlayerList>()
                .As<IPlayerList>();
        }
    }
}