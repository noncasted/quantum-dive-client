using GamePlay.Player.Entity.States.Runs.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = RunRoutes.LogsName,
        menuName = RunRoutes.LogsPath)]
    public class RunLogSettings : LogSettings<RunLogs, RunLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}