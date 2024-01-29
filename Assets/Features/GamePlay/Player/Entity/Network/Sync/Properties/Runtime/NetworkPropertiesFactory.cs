using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Network.Sync.Properties.Common;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Remote.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Network.Sync.Properties.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkPropertiesRoutes.ServiceName,
        menuName = NetworkPropertiesRoutes.ServicePath)]
    public class NetworkPropertiesFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private TransformSyncFactory _transform;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<NetworkPropertiesInjector>()
                .AsCallbackListener();
            
            _transform.Create(services, callbacks);
        }
    }
}