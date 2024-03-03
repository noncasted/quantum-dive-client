using GamePlay.Combat.Targets.Registry.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Combat.Targets.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TargetsRegistryRoutes.ConfigName,
        menuName = TargetsRegistryRoutes.ConfigPath)]
    public class TargetRegistryGizmosConfig : ScriptableObject, ITargetRegistryGizmosConfig
    {
        [SerializeField] private bool _isEnabled;
        [SerializeField] [Min(0f)] private float _duration;

        [SerializeField] [Min(0f)] private float _lineWidth;
        [SerializeField] private Color _lineColor;

        public bool IsEnabled => _isEnabled;
        public float Duration => _duration;

        public float LineWidth => _lineWidth;
        public Color LineColor => _lineColor;
    }
}