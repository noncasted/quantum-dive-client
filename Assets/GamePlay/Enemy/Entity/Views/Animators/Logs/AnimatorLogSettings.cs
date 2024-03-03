using GamePlay.Enemy.Entity.Views.Animators.Common;
using Internal.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Animators.Logs
{
    [CreateAssetMenu(fileName = AnimatorRoutes.LogsName,
        menuName = AnimatorRoutes.LogsPath)]
    public class AnimatorLogSettings : LogSettings<AnimatorLogs, AnimatorLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}