using GamePlay.Player.Entity.Network.TransformSync.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Network.TransformSync.Logs
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TransformSyncRoutes.LogsName, menuName = TransformSyncRoutes.LogsPath)]
    public class TransformSyncLogSettings : LogSettings<TransformSyncLogs, TransformSyncLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}