using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Common.Routes;
using Common.Architecture.Entities.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Architecture.Entities.Common.DefaultCallbacks
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "DefaultCallbacks", menuName = EntityRoutes.Root + "DefaultCallbacks")]
    public class DefaultCallbacksComponentFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var callbacks = new DefaultCallbacksFactory();
            callbacks.AddCallbacks(utils.Callbacks);
        }
    }
}