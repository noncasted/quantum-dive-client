using GamePlay.Projectiles.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Projectiles.Logs
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