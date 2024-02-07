﻿using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;

namespace GamePlay.Enemy.Entity.States.Following.Common
{
    public class FollowingAnimation : LoopedAnimation
    {
        public FollowingAnimation(
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
        }
    }
}