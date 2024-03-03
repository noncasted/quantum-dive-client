using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Internal.Scenes.Logs
{
    [Serializable]
    public class ScenesFlowLogs : ReadOnlyDictionary<ScenesFlowLogType, bool>
    {
    }
}