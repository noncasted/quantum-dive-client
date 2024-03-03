using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.States.Floating.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.States.Floating.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(FloatingStateLogs))]
    public class FloatingStateLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}