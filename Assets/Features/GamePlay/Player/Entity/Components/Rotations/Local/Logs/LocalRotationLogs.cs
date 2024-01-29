using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Logs
{
    [Serializable]
    public class LocalRotationLogs : ReadOnlyDictionary<LocalRotationLogType, bool>
    {
    }
}