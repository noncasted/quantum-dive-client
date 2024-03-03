﻿using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;

namespace GamePlay.Enemy.Entity.States.Damaged.Common
{
    public class DamagedAnimation : AsyncAnimation
    {
        public DamagedAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}