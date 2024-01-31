using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Root.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Root.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordRootRoutes.LocalName, menuName = SwordRootRoutes.LocalPath)]
    public class SwordRootFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SwordRoot>()
                .WithParameter(utils.CallbacksRegistry)
                .AsCallbackListener();
        }
    }
}