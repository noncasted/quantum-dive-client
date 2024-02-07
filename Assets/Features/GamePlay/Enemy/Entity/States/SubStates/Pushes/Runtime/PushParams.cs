using UnityEngine;

namespace GamePlay.Enemy.Entity.States.SubStates.Pushes.Runtime
{
    public readonly struct PushParams
    {
        public PushParams(float time, float distance, AnimationCurve curve)
        {
            Time = time;
            Distance = distance;
            Curve = curve;
        }

        public readonly float Time;
        public readonly float Distance;
        public readonly AnimationCurve Curve;
    }
}