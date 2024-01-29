using GamePlay.Player.Entity.States.Idles.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Idles.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = IdleRoutes.LogsName,
        menuName = IdleRoutes.LogsPath)]
    public class IdleLogSettings : LogSettings<IdleLogs, IdleLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}