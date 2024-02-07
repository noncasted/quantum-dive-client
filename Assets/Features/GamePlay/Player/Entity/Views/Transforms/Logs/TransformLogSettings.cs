using GamePlay.Player.Entity.Views.Transforms.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Logs
{
    [CreateAssetMenu(fileName = TransformRoutes.LogsName,
        menuName = TransformRoutes.LogsPath)]
    public class TransformLogSettings : LogSettings<TransformLogs, TransformLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}