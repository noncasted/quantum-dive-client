using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemy.Spawn.Factory.Logs
{
    [Serializable]
    public class EnemyFactoryLogs : ReadOnlyDictionary<EnemyFactoryLogType, bool>
    {
    }
}