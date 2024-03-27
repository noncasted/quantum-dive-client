using GamePlay.Services.Projectiles.Entity.Views.Actions;
using GamePlay.Services.Projectiles.Entity.Views.Transforms;

namespace GamePlay.Services.Projectiles.Entity.Views.Facade
{
    public interface IProjectileView
    {
        IProjectileTransform Transform { get; }
        IProjectileActions Actions { get; }
    }
}