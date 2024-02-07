using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Entity.Views.Transforms.Logs
{
    [Serializable]
    public class TransformLogs : ReadOnlyDictionary<TransformLogType, bool>
    {
    }
}