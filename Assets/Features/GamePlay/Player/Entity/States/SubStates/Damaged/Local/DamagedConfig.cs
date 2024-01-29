using GamePlay.Player.Entity.States.SubStates.Damaged.Common;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DamagedRoutes.ConfigName,
        menuName = DamagedRoutes.ConfigPath)]
    public class DamagedConfig : ScriptableObject, IDamagedConfig
    {
        [SerializeField] [Min(0)] private int _flickAmount;
        [SerializeField] private Material _material;

        [SerializeField] [Min(0f)] private float _pushTime;
        [SerializeField] [Min(0f)] private float _basePushDistance;
        [SerializeField] [CurveRange(0f, 0f, 0f, 0f)]
        private AnimationCurve _pushCurve;

        public int FlickAmount => _flickAmount;
        public Material Material => _material;

        public float BasePushDistance => _basePushDistance;
        public float Time => _pushTime;
        public AnimationCurve PushCurve => _pushCurve;
    }
}