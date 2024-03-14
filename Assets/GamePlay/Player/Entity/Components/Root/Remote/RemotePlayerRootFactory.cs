using GamePlay.Player.Entity.Common.Definition;
using GamePlay.Player.Entity.Components.Root.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Root.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerRootRoutes.RemoteName, menuName = PlayerRootRoutes.RemotePath)]
    public class RemotePlayerRootFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemotePlayerRoot>()
                .As<IRemotePlayerRoot>()
                .AsCallbackListener();
        }
    }
}