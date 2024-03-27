using GamePlay.Services.Projectiles.Entity.Views.Actions;

namespace GamePlay.Services.Projectiles.Entity.Components
{
    public struct ProjectileActionsComponent
    {
        private IProjectileActions _view;

        public IProjectileActions View => _view;

        public void Construct(IProjectileActions view)
        {
            _view = view;
        }
    }
}