using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemy.Entity.Views.RigidBodies.Logs
{
    [Serializable]
    public class RigidBodyLogs : ReadOnlyDictionary<RigidBodyLogType, bool>
    {
    }
}