using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Common;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Starter;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ProjectileStarterRoutes.ComponentName,
        menuName = ProjectileStarterRoutes.ComponentPath)]
    public class ProjectileStarterFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private ProjectileStarterConfigAsset _config;

        public void Create(IServiceCollection services, ICallbackRegister callbackRegister)
        {
            services.Register<ProjectileStarterConfig>()
                .WithParameter(_config)
                .As<IProjectileStarterConfig>();

            services.Register<ProjectileStarter>()
                .As<IProjectileStarter>()
                .AsCallbackListener();
        }
    }
}