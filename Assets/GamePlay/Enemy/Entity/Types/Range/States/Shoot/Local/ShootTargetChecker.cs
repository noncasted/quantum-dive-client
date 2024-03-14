using GamePlay.Enemy.Entity.Views.Transforms.Local.Abstract;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Services.Combat.Targets.Registry.Abstract;
using GamePlay.Targets.Registry.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local
{
    public class ShootTargetChecker : IShootTargetChecker
    {
        public ShootTargetChecker(
            IEnemyPosition position,
            IShootConfig config)
        {
            _position = position;
            _config = config;
        }
        
        private readonly IEnemyPosition _position;
        private readonly IShootConfig _config;

        private float _lastShootTime = float.MinValue;
        
        public bool IsAvailable(ISearchableTarget target)
        {
            if (Time.time < _lastShootTime + _config.Rate)
                return false;

            var distance = Vector2.Distance(_position.Position, target.Position);

            if (distance > _config.Range)
                return false;

            return true;
        }

        public void OnShoot()
        {
            _lastShootTime = Time.time;
        }
    }
}