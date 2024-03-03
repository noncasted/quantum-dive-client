﻿namespace Common.Tools.UniversalAnimators.Abstract
{
    public class BaseAnimation : IAnimation
    {
        public BaseAnimation(IAnimationData data)
        {
            _data = data;
        }
        
        private readonly IAnimationData _data;

        public IAnimationData Data => _data;
    }
}