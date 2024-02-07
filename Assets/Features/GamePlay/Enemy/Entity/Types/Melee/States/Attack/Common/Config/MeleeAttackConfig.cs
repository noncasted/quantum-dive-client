using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Melee.States.Attack.Common.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.ConfigName,
        menuName = EnemyMeleeAttackRoutes.ConfigPath)]
    public class MeleeAttackConfig : ScriptableObject, IMeleeAttackConfig
    {
        [SerializeField] [Min(0f)] private float _attackRange;
        [SerializeField] [Min(0f)] private float _pushForce;

        [SerializeField] [Min(0f)] private float _dashTime;
        [SerializeField] [Min(0f)] private float _dashDistance;
        [SerializeField] [Min(0f)] private float _damageRadius;

        [SerializeField] [CurveRange(0f, 0f, 0f, 0f)]
        private AnimationCurve _dashCurve;

        public float AttackRange => _attackRange;
        public float PushForce => _pushForce;

        public float DashTime => _dashTime;
        public float DashDistance => _dashDistance;
        public float DamageRadius => _damageRadius;
        public AnimationCurve DashCurve => _dashCurve;
    }
}