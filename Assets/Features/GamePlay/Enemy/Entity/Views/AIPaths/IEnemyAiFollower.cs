using GamePlay.Targets.Registry.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.AIPaths
{
    public interface IEnemyAiFollower
    {
        Vector2 NextPoint { get; }
        void Follow(ISearchableTarget target);
        void Stop();
    }
}