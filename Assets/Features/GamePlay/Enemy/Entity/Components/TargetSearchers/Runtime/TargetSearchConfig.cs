using GamePlay.Enemy.Entity.Components.TargetSearchers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TargetSearcherRoutes.ConfigName,
        menuName = TargetSearcherRoutes.ConfigPath)]
    public class TargetSearchConfig : ScriptableObject, ISearchConfig
    {
        [SerializeField] [Min(0f)] private float _radius;
        [SerializeField] [Min(0f)] private float _stopDistance;

        public float Radius => _radius;
        public float StopDistance => _stopDistance;
    }
}