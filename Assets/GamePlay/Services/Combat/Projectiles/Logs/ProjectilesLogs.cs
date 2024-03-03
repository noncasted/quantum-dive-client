using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Combat.Projectiles.Logs
{
    [Serializable]
    public class ProjectilesLogs : ReadOnlyDictionary<ProjectilesLogType, bool>
    {
    }
}