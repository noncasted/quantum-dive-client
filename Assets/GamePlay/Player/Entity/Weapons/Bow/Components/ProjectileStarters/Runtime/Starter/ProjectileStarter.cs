using Common.DataTypes.Runtime.Structs;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Abstract;
using GamePlay.Projectiles.Factory;
using GamePlay.Projectiles.Registry.Definition;

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
            var shootPosition = _bowShootPoint.Point;
            var direction = angle.ToPlainDirection();
            
            var request = new ProjectileRequest(
                definition,
                shootPosition.position,
                direction,
                parameters);
            
            _projectileFactory.CreateLocalPlayer(request);
        }
    }
}