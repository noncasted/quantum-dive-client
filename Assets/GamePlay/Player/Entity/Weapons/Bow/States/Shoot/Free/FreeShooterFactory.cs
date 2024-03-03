using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Free
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShootRoutes.FreeComponentName,
        menuName = ShootRoutes.FreeComponentPath)]
    public class FreeShooterFactory : ShooterFactory
    {
        [SerializeField] [Indent] private BowShootDefinition _definition;
        [SerializeField] [Indent] private ShootMoveConfig _moveConfig;

        public override void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<FreeShooter>()
                .WithParameter(_definition)
                .WithParameter(_moveConfig)
                .AsCallbackListener()
                .AsSelfResolvable();
        }
    }
}