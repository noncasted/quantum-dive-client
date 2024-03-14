using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Projectiles.Logs
{
    [Serializable]
    public class ProjectilesLogs : ReadOnlyDictionary<ProjectilesLogType, bool>
    {
    }
}