using GamePlay.Player.Entity.Components.Rotations.Remote.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Logs
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteRotationRoutes.LogsName, menuName = RemoteRotationRoutes.LogsPath)]
    public class RemoteRotationLogSettings : LogSettings<RemoteRotationLogs, RemoteRotationLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}