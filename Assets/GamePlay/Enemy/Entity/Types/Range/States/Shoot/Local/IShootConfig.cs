using GamePlay.Services.Projectiles.Factory;
using GamePlay.Services.Projectiles.Registry.Definition;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local
{
    public interface IShootConfig
    {
        IProjectileDefinition Definition { get; }
        ShootParams Params { get; }
        
        float Range { get; }
        float Rate { get; }
    }
}