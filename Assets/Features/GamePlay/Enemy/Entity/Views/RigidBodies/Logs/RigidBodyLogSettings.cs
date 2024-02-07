using GamePlay.Enemies.Entity.Views.RigidBodies.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.RigidBodies.Logs
{
    [CreateAssetMenu(fileName = RigidBodyRoutes.LogsName,
        menuName = RigidBodyRoutes.LogsPath)]
    public class RigidBodyLogSettings : LogSettings<RigidBodyLogs, RigidBodyLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}