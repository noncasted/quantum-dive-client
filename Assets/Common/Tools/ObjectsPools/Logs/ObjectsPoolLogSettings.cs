using Common.Tools.ObjectsPools.Common;
using Internal.Loggers.Runtime;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Logs
{
    [CreateAssetMenu(fileName = ObjectsPoolRoutes.LogsName,
        menuName = ObjectsPoolRoutes.LogsPath)]
    public class ObjectsPoolLogSettings : LogSettings<ObjectsPoolLogs, ObjectsPoolLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}