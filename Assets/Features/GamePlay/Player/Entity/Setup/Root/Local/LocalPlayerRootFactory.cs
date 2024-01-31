using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Setup.Root.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Root.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerRootRoutes.LocalName, menuName = PlayerRootRoutes.LocalPath)]
    public class LocalPlayerRootFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<LocalPlayerRoot>()
                .As<ILocalPlayerRoot>()
                .WithParameter(utils.CallbacksRegistry)
                .AsCallbackListener();
        }
    }
}