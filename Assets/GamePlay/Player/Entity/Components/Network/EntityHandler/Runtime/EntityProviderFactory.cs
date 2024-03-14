using GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EntityHandlerRoutes.ServiceName, menuName = EntityHandlerRoutes.ServicePath)]
    public class EntityProviderFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var callbacks = new PlayerEntityCallbackFactory();
            utils.Callbacks.AddCustomListener(callbacks);
            
            services.Register<EntityProvider>()
                .As<IEntityProvider>()
                .As<IEntityEvents>()
                .As<IPropertyBinder>()
                .AsCallbackListener();
        }
    }
}