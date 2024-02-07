using System.Collections.Generic;
using Global.Debugs.Drawing.Runtime;
using UnityEngine;

namespace GamePlay.Combat.Targets.Registry.Runtime
{
    public class TargetPlayerRegistry : ITargetPlayerRegistry
    {
        public TargetPlayerRegistry(
            IShapeDrawer shapeDrawer,
            ITargetRegistryGizmosConfig gizmosConfig)
        {
            _shapeDrawer = shapeDrawer;
            _gizmosConfig = gizmosConfig;
        }

        private readonly IShapeDrawer _shapeDrawer;
        private readonly ITargetRegistryGizmosConfig _gizmosConfig;

        private readonly List<SearchableTargetPlayer> _players = new();
        private readonly Dictionary<ITargetPosition, SearchableTargetPlayer> _targets = new();

        public IReadOnlyList<ISearchableTarget> Players => _players;

        public bool TryGetNearest(Vector2 origin, out SearchableTargetPlayer nearest)
        {
            nearest = null;

            if (_players.Count == 0)
                return false;

            DrawGizmos(origin, Players);

            var minSqrDistance = float.MaxValue;

            foreach (var player in _players)
            {
                var sqrDistance = (player.Position - origin).sqrMagnitude;

                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    nearest = player;
                }
            }

            return true;
        }

        public void AddPlayer(ITargetPosition position)
        {
            var target = new SearchableTargetPlayer(position);

            _players.Add(target);
            _targets.Add(position, target);
        }

        public void RemovePlayer(ITargetPosition position)
        {
            var target = _targets[position];

            _targets.Remove(position);
            _players.Remove(target);
        }

        private void DrawGizmos(Vector2 origin, IReadOnlyList<ISearchableTarget> players)
        {
            if (_gizmosConfig.IsEnabled == false)
                return;

            foreach (var player in _players)
            {
                _shapeDrawer.DrawLine(
                    _gizmosConfig.Duration,
                    origin,
                    player.Position,
                    _gizmosConfig.LineWidth,
                    _gizmosConfig.LineColor);
            }
        }
    }
}