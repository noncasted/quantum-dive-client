﻿using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;

namespace GamePlay.Enemies.Entity.States.Respawn.Common
{
    public class RespawnAnimation : AsyncAnimation
    {
        public RespawnAnimation(IFrameProvider frameProvider, AnimationData data) : base(frameProvider, data)
        {
        }
    }
}