using GamePlay.Enemies.Entity.Types.Melee.States.Attack.Common.Config;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Targets.Registry.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Melee.States.Attack.Local
{
    public class TargetChecker : ITargetChecker
    {
        public TargetChecker(
            IEnemyPosition position,
            IMeleeAttackConfig config)
        {
            _position = position;
            _config = config;
        }

        private readonly IEnemyPosition _position;
        private readonly IMeleeAttackConfig _config;

        public bool IsAvailable(ISearchableTarget target)
        {
            var distance = Vector2.Distance(_position.Position, target.Position);

            if (distance > _config.AttackRange)
                return false;

            return true;
        }
    }
}