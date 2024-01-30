using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Network.EntityHandler.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Network.EntityHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EntityHandlerRoutes.ServiceName, menuName = EntityHandlerRoutes.ServicePath)]
    public class EntityProviderFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var callbacks = new PlayerEntityCallbackFactory();
            utils.Callbacks.AddGenericCallbackRegister(callbacks);
            
            services.Register<EntityProvider>()
                .As<IEntityProvider>()
                .As<IEntityEvents>()
                .As<IPropertyBinder>()
                .AsCallbackListener();
        }
    }
}