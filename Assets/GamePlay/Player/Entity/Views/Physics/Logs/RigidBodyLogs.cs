using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Entity.Views.Physics.Logs
{
    [Serializable]
    public class RigidBodyLogs : ReadOnlyDictionary<RigidBodyLogType, bool>
    {
    }
}