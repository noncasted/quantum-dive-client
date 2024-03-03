using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Hitbox.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyHitboxRoutes.ConfigName,
        menuName = EnemyHitboxRoutes.ConfigPath)]
    public class HitboxConfig : ScriptableObject, IHitboxConfig
    {
        [SerializeField] [Min(0f)] private float _radius;

        public float Radius => _radius;
    }
}