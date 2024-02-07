using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Services.Factory.Factory.Logs
{
    [Serializable]
    public class PlayerFactoryLogs : ReadOnlyDictionary<PlayerFactoryLogType, bool>
    {
    }
}