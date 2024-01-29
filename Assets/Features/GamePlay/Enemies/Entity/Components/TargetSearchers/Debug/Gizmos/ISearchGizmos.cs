using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.TargetSearchers.Debug.Gizmos
{
    public interface ISearchGizmos
    {
        void DrawSuccessArea(Vector2 origin, float radius);
        void DrawFailArea(Vector2 origin, float radius);
        void DrawSuccessLine(Vector2 origin, Vector2 target);
    }
}