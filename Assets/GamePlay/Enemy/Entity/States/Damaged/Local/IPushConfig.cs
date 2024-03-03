using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Damaged.Local
{
    public interface IPushConfig
    {
        public float Time { get; }
        public float BaseDistance { get; }
        public AnimationCurve Curve { get; }
    }
}