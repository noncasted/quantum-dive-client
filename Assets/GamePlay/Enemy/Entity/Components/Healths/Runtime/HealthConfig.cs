using GamePlay.Enemy.Entity.Components.Healths.Abstract;
using GamePlay.Enemy.Entity.Components.Healths.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Healths.Runtime
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