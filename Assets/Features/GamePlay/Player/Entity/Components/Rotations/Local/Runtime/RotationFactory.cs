using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Rotations.Local.Common;
using GamePlay.Player.Entity.Components.Rotations.Local.Logs;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;

using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalRotationRoutes.ComponentName,
        menuName = LocalRotationRoutes.ComponentPath)]
    public class RotationFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private LocalRotationLogSettings _logSettings;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<LocalRotationLogger>()
                .WithParameter(_logSettings);

            services.Register<Rotation>()
                .As<IRotation>()
                .AsCallbackListener();
        }
    }
}