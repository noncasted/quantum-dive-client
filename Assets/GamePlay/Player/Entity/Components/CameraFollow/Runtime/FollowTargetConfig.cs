using GamePlay.Player.Entity.Components.CameraFollow.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.CameraFollow.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CameraFollowRoutes.ConfigName, menuName = CameraFollowRoutes.ConfigPath)]
    public class FollowTargetConfig : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _moveSpeed;
        [SerializeField] [Min(0f)] private float _rotationSpeed;
        [SerializeField] [Min(0f)] private float _distance;
        [SerializeField] [Min(0f)] private float _xAngle;
        [SerializeField] [Min(0f)] private float _yAngle;

        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;
        public float Distance => _distance;
        public float XAngle => _xAngle;
        public float YAngle => _yAngle;
    }
}