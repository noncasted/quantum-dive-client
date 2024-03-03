using System.Collections.Generic;
using GamePlay.Common.Damages;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime
{
    public class AttackArea : IAttackArea
    {
        public AttackArea(Collider2D collider, IAttackAreaConfig config)
        {
            _collider = collider;
            _transform = collider.transform;    
            _config = config;

            _results = new Collider2D[config.BufferSize];
        }
        
        private readonly Collider2D _collider;
        private readonly Transform _transform;
        private readonly IAttackAreaConfig _config;

        private readonly Collider2D[] _results;

        public IReadOnlyList<IDamageReceiver> GetDamageReceivers(float angle)
        {
            var rotation = Quaternion.Euler(0f, 0f, angle);
            _transform.rotation = rotation;

            var resultsCount = Physics2D.OverlapCollider(_collider, _config.Filter, _results);

            var list = new List<IDamageReceiver>();

            if (resultsCount == 0)
                return list;

            for (var i = 0; i < resultsCount; i++)
            {
                var target = _results[i];

                if (target.TryGetComponent(out IDamageReceiver receiver) == false)
                {
                    Debug.LogError($"Wrong attack trigger with: {target.name}");
                    continue;
                }

                list.Add(receiver);
            }

            return list;
        }
    }
}