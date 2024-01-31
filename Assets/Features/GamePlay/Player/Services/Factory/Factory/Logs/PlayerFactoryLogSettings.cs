using GamePlay.Player.Factory.Factory.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Factory.Factory.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = PlayerFactoryRoutes.LogsName,
        menuName = PlayerFactoryRoutes.LogsPath)]
    public class PlayerFactoryLogSettings : LogSettings<PlayerFactoryLogs, PlayerFactoryLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}