using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemies.Spawn.Factory.Logs
{
    [Serializable]
    public class EnemyFactoryLogs : ReadOnlyDictionary<EnemyFactoryLogType, bool>
    {
    }
}