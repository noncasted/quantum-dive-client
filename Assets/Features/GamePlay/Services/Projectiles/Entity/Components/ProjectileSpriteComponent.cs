using GamePlay.Projectiles.Entity.Views.Sprite;

namespace GamePlay.Projectiles.Entity.Components
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