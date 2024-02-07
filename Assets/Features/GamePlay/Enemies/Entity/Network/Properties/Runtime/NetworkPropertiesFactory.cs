using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Network.Properties.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Network.Properties.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkPropertiesRoutes.ServiceName,
        menuName = NetworkPropertiesRoutes.ServicePath)]
    public class NetworkPropertiesFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<NetworkPropertiesBinder>()
                .AsCallbackListener();
        }
    }
}