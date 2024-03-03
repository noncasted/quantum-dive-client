using GamePlay.Combat.Projectiles.Factory;
using GamePlay.Combat.Projectiles.Registry.Definition;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Starter
{
    public interface IProjectileStarter
    {
        void Shoot(float angle, IProjectileDefinition definition, ShootParams parameters);
    }
}