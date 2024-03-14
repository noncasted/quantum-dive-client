using GamePlay.Player.Entity.Components.Rotations.Local.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = LocalRotationRoutes.LogsName,
        menuName = LocalRotationRoutes.LogsPath)]
    public class LocalRotationLogSettings : LogSettings<LocalRotationLogs, LocalRotationLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}