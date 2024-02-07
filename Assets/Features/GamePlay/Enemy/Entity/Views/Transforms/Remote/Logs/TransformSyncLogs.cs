using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemy.Entity.Views.Transforms.Remote.Logs
{
    [Serializable]
    public class TransformSyncLogs : ReadOnlyDictionary<TransformSyncLogType, bool>
    {
    }
}