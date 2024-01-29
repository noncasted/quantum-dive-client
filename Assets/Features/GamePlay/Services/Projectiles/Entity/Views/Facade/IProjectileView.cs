using GamePlay.Projectiles.Entity.Views.Actions;
using GamePlay.Projectiles.Entity.Views.Sprite;
using GamePlay.Projectiles.Entity.Views.Transforms;

namespace GamePlay.Projectiles.Entity.Views.Facade
{
    public interface IProjectileView
    {
        IProjectileTransform Transform { get; }
        IProjectileActions Actions { get; }
        IProjectileSprite Sprite { get; }
    }
}