using UnityEngine;

namespace GamePlay.Visuals.Cameras.Runtime
{
    public interface ILevelCameraConfig
    {
        float FollowSpeed { get; }

        Sight CreateSight(Vector2 direction, float distance);
    }
}