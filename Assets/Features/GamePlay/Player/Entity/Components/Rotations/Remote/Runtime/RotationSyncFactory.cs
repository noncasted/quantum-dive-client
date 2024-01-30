using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Rotations.Remote.Common;
using GamePlay.Player.Entity.Components.Rotations.Remote.Logs;

using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteRotationRoutes.ComponentName,
        menuName = RemoteRotationRoutes.ComponentPath)]
    public class RotationSyncFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RemoteRotationLogSettings _logSettings;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteRotationLogger>()
                .WithParameter(_logSettings);

            services.Register<RotationSync>()
                .As<IRotationSync>()
                .As<IRemoteRotation>()
                .AsSelf();
        }
    }
}