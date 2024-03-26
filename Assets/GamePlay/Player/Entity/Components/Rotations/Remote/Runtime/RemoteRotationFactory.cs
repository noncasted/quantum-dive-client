using GamePlay.Player.Entity.Components.Rotations.Remote.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Remote.Common;
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
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RotationSync>()
                .As<IRotationSync>()
                .As<IRemoteRotation>()
                .AsSelf();
        }
    }
}