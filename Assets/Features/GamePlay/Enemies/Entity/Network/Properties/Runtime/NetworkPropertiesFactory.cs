using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Network.Properties.Common;
using GamePlay.Enemies.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Network.Properties.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkPropertiesRoutes.ServiceName,
        menuName = NetworkPropertiesRoutes.ServicePath)]
    public class NetworkPropertiesFactory : ScriptableObject, IEnemyComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
        {
            services.Register<NetworkPropertiesBinder>()
                .As<INetworkPropertiesBinder>();
        }
    }
}