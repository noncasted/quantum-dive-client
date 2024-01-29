using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Player.Entity.Views.Sprites.Logs
{
    [Serializable]
    public class SpriteLogs : ReadOnlyDictionary<SpriteLogType, bool>
    {
    }
}