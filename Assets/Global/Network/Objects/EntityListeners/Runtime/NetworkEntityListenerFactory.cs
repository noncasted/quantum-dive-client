using Cysharp.Threading.Tasks;
using Global.Network.Objects.EntityListeners.Abstract;
using Global.Network.Objects.EntityListeners.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Objects.EntityListeners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EntityListenerRoutes.ServiceName, menuName = EntityListenerRoutes.ServicePath)]
    public class NetworkEntityListenerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<EntityListener>()
                .As<IEntityListener>();
        }
    }
}