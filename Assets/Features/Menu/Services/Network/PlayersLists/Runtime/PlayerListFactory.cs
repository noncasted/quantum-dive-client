using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Network.PlayersLists.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Network.PlayersLists.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayersListRoutes.ServiceName,
        menuName = PlayersListRoutes.ServicePath)]
    public class PlayerListFactory : ScriptableObject, IServiceFactory
    {

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<PlayersListHandler>()
                .As<IPlayersList>()
                .AsCallbackListener();
        }
    }
}