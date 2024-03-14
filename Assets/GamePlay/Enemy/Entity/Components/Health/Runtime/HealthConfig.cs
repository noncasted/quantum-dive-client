using GamePlay.Enemy.Entity.Components.Health.Abstract;
using GamePlay.Enemy.Entity.Components.Health.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Health.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyHealthRoutes.ConfigName,
        menuName = EnemyHealthRoutes.ConfigPath)]
    public class HealthConfig : ScriptableObject, IHealthConfig
    {
        [SerializeField] [Min(1)] private int _max;

        public int Max => _max;
    }
}