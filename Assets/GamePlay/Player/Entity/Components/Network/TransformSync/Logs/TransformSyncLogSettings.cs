using GamePlay.Player.Entity.Components.Network.TransformSync.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Network.TransformSync.Logs
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TransformSyncRoutes.LogsName, menuName = TransformSyncRoutes.LogsPath)]
    public class TransformSyncLogSettings : LogSettings<TransformSyncLogs, TransformSyncLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}