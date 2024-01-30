using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Network.Sync.Properties.Common;
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

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<NetworkPropertiesInjector>()
                .AsCallbackListener();

            _transform.Create(services, utils);
        }
    }
}