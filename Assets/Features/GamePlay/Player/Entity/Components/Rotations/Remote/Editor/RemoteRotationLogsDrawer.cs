using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Components.Rotations.Remote.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(RemoteRotationLogs))]
    public class RemoteRotationLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}