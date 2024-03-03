using GamePlay.Player.Entity.States.None.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.None.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = NoneRoutes.LogsName,
        menuName = NoneRoutes.LogsPath)]
    public class NoneLogSettings : LogSettings<NoneLogs, NoneLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}