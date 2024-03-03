using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Entity.States.Idles.Logs
{
    [Serializable]
    public class IdleLogs : ReadOnlyDictionary<IdleLogType, bool>
    {
    }
}