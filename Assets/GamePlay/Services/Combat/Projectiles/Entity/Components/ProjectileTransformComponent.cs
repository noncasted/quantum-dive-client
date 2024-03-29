﻿using GamePlay.Services.Projectiles.Entity.Views.Transforms;

namespace GamePlay.Services.Projectiles.Entity.Components
{
    public struct ProjectileTransformComponent
    {
        public void Construct(IProjectileTransform transform)
        {
            _view = transform;
        }

        private IProjectileTransform _view;

        public IProjectileTransform View => _view;
    }
}