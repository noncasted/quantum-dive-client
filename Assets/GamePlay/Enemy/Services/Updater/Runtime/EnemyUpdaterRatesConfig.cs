using GamePlay.Enemy.Services.Updater.Abstract;
using GamePlay.Enemy.Updater.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Updater.Runtime
{
    [InlineEditor]
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