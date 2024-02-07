using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Local.Logs
{
    [Serializable]
    public class LocalStateMachineLogs : ReadOnlyDictionary<LocalStateMachineLogType, bool>
    {
    }
}