using Cysharp.Threading.Tasks;
using GamePlay.Network.Objects.Destroyer.Common;
using GamePlay.Services.System.Network.Objects.Destroyer.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Objects.Destroyer.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EntityDestroyerRoutes.ServiceName,
        menuName = EntityDestroyerRoutes.ServicePath)]
    public class NetworkEntityDestroyerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<NetworkEntityDestroyer>()
                .As<INetworkEntityDestroyer>();
        }
    }
}