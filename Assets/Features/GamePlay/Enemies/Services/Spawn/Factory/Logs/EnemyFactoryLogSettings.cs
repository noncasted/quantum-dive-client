using GamePlay.Enemies.Services.Spawn.Factory.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Factory.Logs
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFactoryRoutes.LogsName, menuName = EnemyFactoryRoutes.LogsPath)]
    public class EnemyFactoryLogSettings : LogSettings<EnemyFactoryLogs, EnemyFactoryLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}