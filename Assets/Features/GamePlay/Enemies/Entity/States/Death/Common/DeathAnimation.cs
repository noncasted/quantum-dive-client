﻿using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;

namespace GamePlay.Enemies.Entity.States.Death.Common
{
    public class DeathAnimation : AsyncAnimation
    {
        public DeathAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}