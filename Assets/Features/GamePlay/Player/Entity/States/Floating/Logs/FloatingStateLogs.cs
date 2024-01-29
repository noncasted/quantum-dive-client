using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Entity.States.Floating.Logs
{
    [Serializable]
    public class FloatingStateLogs : ReadOnlyDictionary<FloatingStateLogType, bool>
    {
    }
}