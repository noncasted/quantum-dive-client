using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Remote.Logs
{
    [Serializable]
    public class RemoteStateMachineLogs : ReadOnlyDictionary<RemoteStateMachineLogType, bool>
    {
    }
}