using GamePlay.Combat.Projectiles.Entity.Views.Actions;
using GamePlay.Combat.Projectiles.Entity.Views.Sprite;
using GamePlay.Combat.Projectiles.Entity.Views.Transforms;

namespace GamePlay.Combat.Projectiles.Entity.Views.Facade
{
    public interface IProjectileView
    {
        IProjectileTransform Transform { get; }
        IProjectileActions Actions { get; }
        IProjectileSprite Sprite { get; }
    }
}