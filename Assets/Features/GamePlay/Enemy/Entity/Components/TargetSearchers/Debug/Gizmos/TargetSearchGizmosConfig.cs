using GamePlay.Enemy.Entity.Components.TargetSearchers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Debug.Gizmos
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TargetSearcherRoutes.GizmosConfigName,
        menuName = TargetSearcherRoutes.GizmosConfigPath)]
    public class TargetSearchGizmosConfig : ScriptableObject, ISearchGizmosConfig
    {
        [SerializeField] private bool _isEnabled;
        [SerializeField] [Min(0f)] private float _duration;

        [SerializeField] [Min(0f)] private float _targetLineWidth;
        [SerializeField] private Color _targetLineColor;

        [SerializeField] [Min(0f)] private float _areaWidth;
        [SerializeField] private Color _successAreaColor;
        [SerializeField] private Color _failAreaColor;

        public bool IsEnabled => _isEnabled;
        public float Duration => _duration;

        public float TargetLineWidth => _targetLineWidth;
        public Color TargetLineColor => _targetLineColor;

        public float AreaWidth => _areaWidth;
        public Color SuccessAreaColor => _successAreaColor;
        public Color FailAreaColor => _failAreaColor;
    }
}