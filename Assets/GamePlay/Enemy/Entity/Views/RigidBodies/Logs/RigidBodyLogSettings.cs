using GamePlay.Enemy.Entity.Views.RigidBodies.Common;
using Internal.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.RigidBodies.Logs
{
    [CreateAssetMenu(fileName = RigidBodyRoutes.LogsName,
        menuName = RigidBodyRoutes.LogsPath)]
    public class RigidBodyLogSettings : LogSettings<RigidBodyLogs, RigidBodyLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}