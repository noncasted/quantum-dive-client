using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.Components.Network.Properties.Common;
using Internal.Scopes.Abstract.Containers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Network.Properties.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkPropertiesRoutes.ServiceName,
        menuName = NetworkPropertiesRoutes.ServicePath)]
    public class NetworkPropertiesFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<NetworkPropertiesBinder>()
                .AsCallbackListener();
        }
    }
}