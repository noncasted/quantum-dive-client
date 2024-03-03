using GamePlay.Player.Entity.States.Respawns.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Respawns.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = RespawnRoutes.LogsName,
        menuName = RespawnRoutes.LogsPath)]
    public class RespawnLogSettings : LogSettings<RespawnLogs, RespawnLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}