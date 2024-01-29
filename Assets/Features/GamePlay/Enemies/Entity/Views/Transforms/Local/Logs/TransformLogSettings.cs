using GamePlay.Enemies.Entity.Views.Transforms.Local.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Transforms.Local.Logs
{
    [CreateAssetMenu(fileName = TransformRoutes.LogsName,
        menuName = TransformRoutes.LogsPath)]
    public class TransformLogSettings : LogSettings<TransformLogs, TransformLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}