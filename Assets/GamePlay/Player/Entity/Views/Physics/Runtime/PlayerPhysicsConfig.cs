using GamePlay.Player.Entity.Views.Physics.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerPhysicsRoutes.ConfigName, menuName = PlayerPhysicsRoutes.ConfigPath)]
    public class PlayerPhysicsConfig : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _rotationSpeed;

        public float RotationSpeed => _rotationSpeed;
    }
}