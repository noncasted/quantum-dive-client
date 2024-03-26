using GamePlay.Enemy.Entity.Views.Transforms.Remote.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Remote.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TransformSyncRoutes.ServiceName,
        menuName = TransformSyncRoutes.ServicePath)]
    public class TransformSyncFactory : ScriptableObject, IComponentFactory
    {
       public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {

            services.Register<TransformSync>()
                .AsCallbackListener();
        }
    }
}