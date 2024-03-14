using System;
using NaughtyAttributes;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Abstract
{
    [Serializable]
    public class PushParams
    {
        public PushParams(
            float time,
            float distance,
            AnimationCurve curve)
        {
            _time = time;
            _distance = distance;
            _curve = curve;
        }

        [SerializeField] private float _time;
        [SerializeField] private float _distance;

        [SerializeField] [CurveRange(0f, 0f, 1f, 1f)]
        private AnimationCurve _curve;

        public float Time => _time;
        public float Distance => _distance;
        public AnimationCurve Curve => _curve;
    }
}