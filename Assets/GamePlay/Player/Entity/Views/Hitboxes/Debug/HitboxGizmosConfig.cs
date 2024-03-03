using GamePlay.Player.Entity.Views.Hitboxes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Hitboxes.Debug
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HitboxRoutes.GizmosConfigName,
        menuName = HitboxRoutes.GizmosConfigPath)]
    public class HitboxGizmosConfig : ScriptableObject, IHitboxGizmosConfig
    {
        [SerializeField] private Color _color;
        [SerializeField][Min(0f)] private float _width;

        public Color Color => _color;
        public float Width => _width;
    }
}