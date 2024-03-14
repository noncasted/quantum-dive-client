using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.Components.Network.EntityHandler.Common;
using Internal.Scopes.Abstract.Containers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Network.EntityHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EntityProviderRoutes.ComponentName, menuName = EntityProviderRoutes.ComponentPath)]
    public class EntityProviderFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<EntityProvider>()
                .As<IEntityProvider>()
                .AsCallbackListener();
        }
    }
}