using GamePlay.Projectiles.Factory;
using GamePlay.Projectiles.Registry.Definition;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Starter
{
    public interface IProjectileStarter
    {
        void Shoot(float angle, IProjectileDefinition definition, ShootParams parameters);
    }
}