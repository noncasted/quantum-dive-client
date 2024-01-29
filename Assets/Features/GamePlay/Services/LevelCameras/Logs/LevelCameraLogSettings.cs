﻿using GamePlay.LevelCameras.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.LevelCameras.Logs
{
    [CreateAssetMenu(fileName = LevelCameraRoutes.LogsName,
        menuName = LevelCameraRoutes.LogsPath)]
    public class LevelCameraLogSettings : LogSettings<LevelCameraLogs, LevelCameraLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}