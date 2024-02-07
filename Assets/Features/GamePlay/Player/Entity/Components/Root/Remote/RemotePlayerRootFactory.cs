using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Root.Common;
using GamePlay.Player.Entity.Definition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Root.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerRootRoutes.RemoteName, menuName = PlayerRootRoutes.RemotePath)]
    public class RemotePlayerRootFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemotePlayerRoot>()
                .As<IRemotePlayerRoot>()
                .WithParameter(utils.CallbacksRegistry)
                .AsCallbackListener();
        }
    }
}