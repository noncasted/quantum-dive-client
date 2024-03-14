using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Remote.Logs
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteStateMachineRoutes.LogsName, menuName = RemoteStateMachineRoutes.LogsPath)]
    public class RemoteStateMachineLogSettings : LogSettings<RemoteStateMachineLogs, RemoteStateMachineLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}