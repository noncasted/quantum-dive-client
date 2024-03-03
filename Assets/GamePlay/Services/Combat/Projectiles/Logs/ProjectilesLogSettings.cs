﻿using GamePlay.Combat.Projectiles.Common;
using Internal.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = ProjectilesRoutes.LogsName,
        menuName = ProjectilesRoutes.LogsPath)]
    public class ProjectilesLogSettings : LogSettings<ProjectilesLogs, ProjectilesLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}