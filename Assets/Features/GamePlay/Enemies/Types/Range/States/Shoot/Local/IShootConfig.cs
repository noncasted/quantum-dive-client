using GamePlay.Projectiles.Factory;
using GamePlay.Projectiles.Registry.Definition;

namespace GamePlay.Enemies.Types.Range.States.Shoot.Local
{
    public interface IShootConfig
    {
        IProjectileDefinition Definition { get; }
        ShootParams Params { get; }
        
        float Range { get; }
        float Rate { get; }
    }
}