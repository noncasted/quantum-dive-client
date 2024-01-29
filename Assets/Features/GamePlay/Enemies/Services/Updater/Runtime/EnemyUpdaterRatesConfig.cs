using GamePlay.Enemies.Services.Updater.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Services.Updater.Runtime
{
    [InlineEditor()]
    [CreateAssetMenu(fileName = EnemyUpdaterRoutes.ConfigName,
        menuName = EnemyUpdaterRoutes.ConfigPath)]
    public class EnemyUpdaterRatesConfig : ScriptableObject, IRatesConfig
    {
        [SerializeField] [Min(0f)] private float _targetSearchRate;
        [SerializeField] [Min(0f)] private float _pathRecalculateRate;
        [SerializeField] [Min(0f)] private float _stateSelectionRate;

        public float TargetSearchRate => _targetSearchRate;
        public float PathRecalculateRate => _pathRecalculateRate;
        public float StateSelectionRate => _stateSelectionRate;
    }
}