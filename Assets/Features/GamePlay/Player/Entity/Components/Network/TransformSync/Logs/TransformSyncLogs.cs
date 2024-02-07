using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Entity.Components.Network.TransformSync.Logs
{
    [Serializable]
    public class TransformSyncLogs : ReadOnlyDictionary<TransformSyncLogType, bool>
    {
    }
}