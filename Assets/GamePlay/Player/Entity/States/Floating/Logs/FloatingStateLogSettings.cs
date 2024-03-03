using GamePlay.Player.Entity.States.Floating.Common;
using Internal.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Floating.Logs
{
    [CreateAssetMenu(fileName = FloatingRoutes.LogsName,
        menuName = FloatingRoutes.LogsPath)]
    public class FloatingStateLogSettings : LogSettings<FloatingStateLogs, FloatingStateLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}