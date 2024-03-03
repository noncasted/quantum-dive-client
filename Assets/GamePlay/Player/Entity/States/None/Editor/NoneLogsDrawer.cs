using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.States.None.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.States.None.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(NoneLogs))]
    public class NoneLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}