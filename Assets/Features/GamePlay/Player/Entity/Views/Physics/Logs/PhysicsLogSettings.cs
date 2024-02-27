using GamePlay.Player.Entity.Views.Physics.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Logs
{
    [CreateAssetMenu(fileName = RigidBodyRoutes.LogsName,
        menuName = RigidBodyRoutes.LogsPath)]
    public class PhysicsLogSettings : LogSettings<RigidBodyLogs, RigidBodyLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}