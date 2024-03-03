using GamePlay.Player.Entity.Components.StateMachines.Local.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = LocalStateMachineRoutes.LogsName,
        menuName = LocalStateMachineRoutes.LogsPath)]
    public class LocalStateMachineLogSettings : LogSettings<LocalStateMachineLogs, LocalStateMachineLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}