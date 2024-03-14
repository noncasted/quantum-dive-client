using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Global.Network.EventsRegistries.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.EventsRegistries.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EventsRegistryRoutes.ServiceName,
        menuName = EventsRegistryRoutes.ServicePath)]
    public class EventsRegistryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<NetworkEventsRegistry>()
                .AsCallbackListener();
        }
    }
}