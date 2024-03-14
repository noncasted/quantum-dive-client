using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.Views.Transforms.Remote.Common;
using GamePlay.Enemy.Entity.Views.Transforms.Remote.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Remote.Runtime
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