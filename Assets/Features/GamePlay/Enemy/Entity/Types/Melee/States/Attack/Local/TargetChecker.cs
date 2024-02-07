using GamePlay.Combat.Targets.Registry.Runtime;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Config;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Local
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