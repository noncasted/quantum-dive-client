using Common.DataTypes.Structs;
using GamePlay.Combat.Projectiles.Factory;
using GamePlay.Combat.Projectiles.Registry.Definition;
using GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Starter
{
    public class ProjectileStarter : IProjectileStarter
    {
        public ProjectileStarter(
            IProjectileFactory projectileFactory,
            IBowShootPoint bowShootPoint)
        {
            _projectileFactory = projectileFactory;
            _bowShootPoint = bowShootPoint;
        }

        private readonly IProjectileFactory _projectileFactory;
        private readonly IBowShootPoint _bowShootPoint;

        public void Shoot(float angle, IProjectileDefinition definition, ShootParams parameters)
        {
            var side = AngleUtils.ToHorizontal(angle);
            var shootPosition = _bowShootPoint.Point;
            var direction = angle.ToDirection();

            var request = new ProjectileRequest(
                definition,
                shootPosition.position,
                direction,
                parameters);
            
            _projectileFactory.CreateLocalPlayer(request);
        }
    }
}