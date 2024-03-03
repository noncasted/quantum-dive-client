using UnityEngine;

namespace Common.Tools.UniversalAnimators.Abstract
{
    public class AnimationData : IAnimationData
    {
        public AnimationData(
            AnimationClip clip,
            float fadeDuration,
            float time,
            int layer)
        {
            Clip = clip;
            FadeDuration = fadeDuration;
            Time = time;
            Layer = layer;
        }

        public AnimationClip Clip { get; }
        public float Time { get; }
        public float FadeDuration { get; }
        public int Layer { get; }
    }
}