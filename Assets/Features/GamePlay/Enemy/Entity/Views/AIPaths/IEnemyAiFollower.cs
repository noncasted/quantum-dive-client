using GamePlay.Combat.Targets.Registry.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.AIPaths
{
    public interface IEnemyAiFollower
    {
        Vector2 NextPoint { get; }
        void Follow(ISearchableTarget target);
        void Stop();
    }
}