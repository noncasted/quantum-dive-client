using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemies.Services.Spawn.Factory.Logs
{
    [Serializable]
    public class EnemyFactoryLogs : ReadOnlyDictionary<EnemyFactoryLogType, bool>
    {
    }
}