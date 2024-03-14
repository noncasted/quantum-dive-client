using GamePlay.Enemy.Entity.Components.StateMachines.Local.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Local.Logs
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