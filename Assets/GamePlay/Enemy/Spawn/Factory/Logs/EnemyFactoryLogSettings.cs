using GamePlay.Enemy.Spawn.Factory.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Factory.Logs
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFactoryRoutes.LogsName, menuName = EnemyFactoryRoutes.LogsPath)]
    public class EnemyFactoryLogSettings : LogSettings<EnemyFactoryLogs, EnemyFactoryLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}