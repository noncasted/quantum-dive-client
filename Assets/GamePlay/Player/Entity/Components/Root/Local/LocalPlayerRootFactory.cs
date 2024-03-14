using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Common.Definition;
using GamePlay.Player.Entity.Components.Root.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Root.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerRootRoutes.LocalName, menuName = PlayerRootRoutes.LocalPath)]
    public class LocalPlayerRootFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalPlayerRoot>()
                .As<ILocalPlayerRoot>()
                .AsCallbackListener();
        }
    }
}