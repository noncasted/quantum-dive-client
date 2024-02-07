using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Factory.Factory.Logs;
using UnityEditor;

namespace GamePlay.Player.Factory.Factory.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(PlayerFactoryLogs))]
    public class PlayerFactoryLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}