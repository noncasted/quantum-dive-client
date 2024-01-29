using System;
using System.Collections.Generic;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.FrameSequence;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Animation
{
    public class RotatableFrameProvider : IFrameProvider, IRotatableFrameProvider
    {
        public RotatableFrameProvider(RotatableAnimationFactory factory)
        {
            _up = factory.Up;
            _sideBack = factory.SideBack;
            _side = factory.Side;
            _sideFace = factory.SideFace;
            _down = factory.Down;
            FramesCount = _up.Count;

            _name = factory.name;
            ValidateFrames();
        }

        private readonly string _name;
        private readonly IReadOnlyList<IFrameData> _up;
        private readonly IReadOnlyList<IFrameData> _sideBack;
        private readonly IReadOnlyList<IFrameData> _side;
        private readonly IReadOnlyList<IFrameData> _sideFace;
        private readonly IReadOnlyList<IFrameData> _down;

        private PlayerOrientation _orientation = PlayerOrientation.Down;

        public int FramesCount { get; }

        public IFrameData GetFrame(int index)
        {
            var frames = _orientation switch
            {
                PlayerOrientation.SideFace => _sideFace,
                PlayerOrientation.SideBack => _sideBack,
                PlayerOrientation.Up => _up,
                PlayerOrientation.Down => _down,
                PlayerOrientation.Side => _side,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            return frames[index];
        }

        public void SetOrientation(PlayerOrientation orientation)
        {
            _orientation = orientation;
        }

        private void ValidateFrames()
        {
            var frameCounts = new[]
            {
                _up.Count, _down.Count, _side.Count, _sideFace.Count, _sideBack.Count
            };

            var check = _up.Count;

            foreach (var count in frameCounts)
            {
                if (count != check)
                    Debug.LogError($"Rotatable animation {_name} have different frames amount in animations");
            }
        }
    }
}