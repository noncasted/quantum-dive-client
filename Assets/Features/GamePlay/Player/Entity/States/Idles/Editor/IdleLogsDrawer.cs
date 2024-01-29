using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.States.Idles.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.States.Idles.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(IdleLogs))]
    public class IdleLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}