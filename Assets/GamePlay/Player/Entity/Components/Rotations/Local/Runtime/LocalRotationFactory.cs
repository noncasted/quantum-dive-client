using GamePlay.Player.Entity.Components.Rotations.Local.Common;
using GamePlay.Player.Entity.Components.Rotations.Local.Logs;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalRotationRoutes.ComponentName,
        menuName = LocalRotationRoutes.ComponentPath)]
    public class LocalRotationFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private LocalRotationLogSettings _logSettings;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalRotationLogger>()
                .WithParameter(_logSettings);

            services.Register<AngleSteering>()
                .As<IAngleSteering>();
            
            services.Register<LocalRotation>()
                .As<IRotation>()
                .AsCallbackListener();
        }
    }
}