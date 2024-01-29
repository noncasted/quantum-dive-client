using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Remote.Common;
using GamePlay.Player.Entity.Views.Transforms.Remote.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Remote.Runtime
{
    [Indent]
    [CreateAssetMenu(fileName = TransformSyncRoutes.ServiceName,
        menuName = TransformSyncRoutes.ServicePath)]
    public class TransformSyncFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private TransformSyncLogSettings _logSettings;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<TransformSyncLogger>()
                .WithParameter(_logSettings);

            services.Register<TransformSync>()
                .AsCallbackListener();
        }
    }
}