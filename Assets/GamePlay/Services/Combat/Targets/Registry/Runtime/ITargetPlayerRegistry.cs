using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Combat.Targets.Registry.Runtime
{
    public interface ITargetPlayerRegistry
    {
        IReadOnlyList<ISearchableTarget> Players { get; }

        bool TryGetNearest(Vector3 origin, out SearchableTargetPlayer nearest);
        void AddPlayer(ITargetPosition position);
        void RemovePlayer(ITargetPosition position);
    }
}