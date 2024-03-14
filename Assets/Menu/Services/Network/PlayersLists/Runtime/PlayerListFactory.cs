using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Menu.Services.Network.PlayersLists.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Services.Network.PlayersLists.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayersListRoutes.ServiceName,
        menuName = PlayersListRoutes.ServicePath)]
    public class PlayerListFactory : ScriptableObject, IServiceFactory
    {

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<PlayersListHandler>()
                .As<IPlayersList>()
                .AsCallbackListener();
        }
    }
}