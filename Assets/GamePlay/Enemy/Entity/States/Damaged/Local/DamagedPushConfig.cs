using GamePlay.Enemy.Entity.States.Damaged.Common;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Damaged.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamagedRoutes.ConfigName,
        menuName = EnemyDamagedRoutes.ConfigPath)]
    public class DamagedPushConfig : ScriptableObject, IPushConfig
    {
        [SerializeField] [Min(0f)] private float _time;
        [SerializeField] [Min(0f)] private float _baseDistance;
        [SerializeField] [CurveRange(0f, 0f, 1f, 1f)]
        private AnimationCurve _curve;
        
        public float Time => _time;
        public float BaseDistance => _baseDistance;
        public AnimationCurve Curve => _curve;
    }
}