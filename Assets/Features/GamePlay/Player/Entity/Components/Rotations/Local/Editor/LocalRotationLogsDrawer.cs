using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Components.Rotations.Local.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LocalRotationLogs))]
    public class LocalRotationLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}