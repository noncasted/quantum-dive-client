﻿using UnityEngine;

namespace GamePlay.Cameras.Runtime
{
    public interface ILevelCameraConfig
    {
        float FollowSpeed { get; }

        Sight CreateSight(Vector2 direction, float distance);
    }
}