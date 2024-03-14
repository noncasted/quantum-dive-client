using GamePlay.Player.Entity.Components.Rotations.Remote.Common;
using GamePlay.Player.Entity.Components.Rotations.Remote.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteRotationRoutes.ComponentName,
        menuName = RemoteRotationRoutes.ComponentPath)]
    public class RemoteRotationFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RemoteRotationLogSettings _logSettings;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
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