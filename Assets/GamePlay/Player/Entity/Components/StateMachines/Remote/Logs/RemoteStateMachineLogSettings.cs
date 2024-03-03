using GamePlay.Player.Entity.Components.StateMachines.Remote.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Logs
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteStateMachineRoutes.LogsName, menuName = RemoteStateMachineRoutes.LogsPath)]
    public class RemoteStateMachineLogSettings : LogSettings<RemoteStateMachineLogs, RemoteStateMachineLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}