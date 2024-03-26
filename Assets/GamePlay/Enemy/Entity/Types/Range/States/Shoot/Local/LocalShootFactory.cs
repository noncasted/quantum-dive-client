using GamePlay.Enemy.Entity.Types.Range.States.Shoot.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyShootRoutes.LocalName,
        menuName = EnemyShootRoutes.LocalPath)]
    public class LocalShootFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private ShootDefinition _definition;
        [SerializeField] private ShootConfig _config;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<ShootTargetChecker>()
                .WithParameter<IShootConfig>(_config)
                .As<IShootTargetChecker>();
            
            services.Register<LocalShoot>()
                .WithParameter(_definition)
                .WithParameter<IShootConfig>(_config)
                .As<IShoot>();
            
            services.Register<ShootTransition>()
                .WithParameter(_definition)
                .As<IShootTransition>();
        }
    }
}