﻿using System.Collections.Generic;
using Common.Tools.UniversalAnimators.Old.Animations.Abstract;
using Common.Tools.UniversalAnimators.Old.Animations.FrameSequence;

namespace Common.Tools.UniversalAnimators.Old.Animations.FrameProviders.Forward
{
    public class ForwardFrameProvider : IFrameProvider
    {
        public ForwardFrameProvider(IReadOnlyList<IFrameData> sprites)
        {
            _sprites = sprites;

            FramesCount = _sprites.Count;
        }
        
        private readonly IReadOnlyList<IFrameData> _sprites;
        
        public int FramesCount { get; }
        
        public IFrameData GetFrame(int index)
        {
            return _sprites[index];
        }
    }
}