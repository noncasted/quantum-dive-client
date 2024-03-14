using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Services.Combat.Targets.Registry.Abstract
{
    public interface ITargetPlayerRegistry
    {
        IReadOnlyList<ISearchableTarget> Players { get; }

        bool TryGetNearest(Vector3 origin, out SearchableTargetPlayer nearest);
        void AddPlayer(ITargetPosition position);
        void RemovePlayer(ITargetPosition position);
    }
}