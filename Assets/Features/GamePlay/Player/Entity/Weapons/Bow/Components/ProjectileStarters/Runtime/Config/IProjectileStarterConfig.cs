using GamePlay.Projectiles.Factory;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config
{
    public interface IProjectileStarterConfig
    {
        ProjectileData Data { get; }
        ShootParams Params { get; }
    }
}