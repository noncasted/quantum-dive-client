﻿using GamePlay.Enemies.Entity.Views.Animators.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Animators.Logs
{
    [CreateAssetMenu(fileName = AnimatorRoutes.LogsName,
        menuName = AnimatorRoutes.LogsPath)]
    public class AnimatorLogSettings : LogSettings<AnimatorLogs, AnimatorLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}