using GamePlay.System.Network.Messaging.Events.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.System.Network.Messaging.Events.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = NetworkEventsRoutes.LogsName,
        menuName = NetworkEventsRoutes.LogsPath)]
    public class NetworkEventsLogSettings : LogSettings<NetworkEventsLogs, NetworkEventsLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}