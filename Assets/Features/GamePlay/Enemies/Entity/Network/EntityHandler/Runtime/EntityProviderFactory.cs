using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Network.EntityHandler.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Network.EntityHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EntityProviderRoutes.ComponentName, menuName = EntityProviderRoutes.ComponentPath)]
    public class EntityProviderFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<EntityProvider>()
                .As<IEntityProvider>()
                .AsCallbackListener();
        }
    }
}