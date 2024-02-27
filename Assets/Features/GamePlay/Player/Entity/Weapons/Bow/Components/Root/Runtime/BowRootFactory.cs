using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Root.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Root.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowRootRoutes.LocalName, menuName = BowRootRoutes.LocalPath)]
    public class BowRootFactory : ScriptableObject, IComponentFactory
    {
        
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowRoot>()
                .WithParameter(utils.CallbacksRegistry)
                .AsCallbackListener();
        }
    }
}