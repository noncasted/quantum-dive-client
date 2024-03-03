using UnityEngine;

namespace Common.Tools.UniversalAnimators.Abstract
{
    public interface IAnimationData
    {
        AnimationClip Clip { get; }
        float Time { get; }
        float FadeDuration { get; }
        int Layer { get; }
    }
}