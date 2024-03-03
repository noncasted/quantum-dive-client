using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Logs
{
    [Serializable]
    public class RemoteRotationLogs : ReadOnlyDictionary<RemoteRotationLogType, bool>
    {
    }
}