using GamePlay.Services.Projectiles.Factory;
using GamePlay.Services.Projectiles.Registry.Definition;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract
{
    public interface IProjectileStarter
    {
        void Shoot(float angle, IProjectileDefinition definition, ShootParams parameters);
    }
}