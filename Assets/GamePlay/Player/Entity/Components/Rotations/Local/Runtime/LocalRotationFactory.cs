using GamePlay.Player.Entity.Components.Rotations.Local.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Local.Common;
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
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<AngleSteering>()
                .As<IAngleSteering>();
            
            services.Register<LocalRotation>()
                .As<IRotation>()
                .AsCallbackListener();
        }
    }
}