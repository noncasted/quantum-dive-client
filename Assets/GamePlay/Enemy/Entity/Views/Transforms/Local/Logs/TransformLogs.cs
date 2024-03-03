using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Logs
{
    [Serializable]
    public class TransformLogs : ReadOnlyDictionary<TransformLogType, bool>
    {
    }
}