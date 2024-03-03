﻿using GamePlay.System.Network.Messaging.REST.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.System.Network.Messaging.REST.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = MessengerRoutes.LogsName,
        menuName = MessengerRoutes.LogsPath)]
    public class MessengerLogSettings : LogSettings<MessengerLogs, MessengerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}