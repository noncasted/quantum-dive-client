using GamePlay.Combat.Projectiles.Entity.Views.Sprite;

namespace GamePlay.Combat.Projectiles.Entity.Components
{
    public struct ProjectileSpriteComponent
    {
        public void Construct(IProjectileSprite transform)
        {
            _view = transform;
        }

        private IProjectileSprite _view;

        public IProjectileSprite View => _view;
    }
}