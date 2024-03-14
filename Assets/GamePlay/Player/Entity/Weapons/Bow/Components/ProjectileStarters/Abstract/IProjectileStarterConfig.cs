namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract
{
    public interface IProjectileStarterConfig
    {
        ProjectileData Data { get; }
        float Scale { get; }
        float Radius { get; }
    }
}