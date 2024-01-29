using GamePlay.Player.Entity.Views.RigidBodies.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RigidBodies.Debug.Gizmos
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RigidBodyRoutes.GizmosConfigName,
        menuName = RigidBodyRoutes.GizmosConfigPath)]
    public class RigidBodyGizmosConfig : ScriptableObject, IGizmosConfig
    {
        [SerializeField] private Color _color;
        [SerializeField] [Min(0f)] private float _width;

        public Color Color => _color;
        public float Width => _width;
    }
}