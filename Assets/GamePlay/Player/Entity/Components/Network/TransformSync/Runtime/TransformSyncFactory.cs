using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Components.Network.TransformSync.Common;
using GamePlay.Player.Entity.Components.Network.TransformSync.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Network.TransformSync.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TransformSyncRoutes.ServiceName,
        menuName = TransformSyncRoutes.ServicePath)]
    public class TransformSyncFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private TransformSyncLogSettings _logSettings;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<TransformSyncLogger>()
                .WithParameter(_logSettings);

            services.Register<TransformSync>()
                .AsCallbackListener();
        }
    }
}