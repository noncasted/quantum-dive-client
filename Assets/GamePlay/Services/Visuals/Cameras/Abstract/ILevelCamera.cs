﻿using UnityEngine;

namespace GamePlay.Visuals.Cameras.Abstract
{
    public interface ILevelCamera
    {
        Camera Camera { get; }

        void StartFollow(IFollowTarget target);
        void StopFollow();
        void Teleport(Vector2 target);
        void SetSize(float size);
    }
}