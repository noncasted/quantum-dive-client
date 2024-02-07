using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Debug
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.GizmosConfigName,
        menuName = EnemyMeleeAttackRoutes.GizmosConfigPath)]
    public class MeleeAttackGizmosConfig : ScriptableObject, IMeleeAttackGizmosConfig
    {
        [SerializeField] private Color _color;
        [SerializeField][Min(0f)] private float _width;

        public Color Color => _color;
        public float Width => _width;
    }
}