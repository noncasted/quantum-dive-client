using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Components.Network.TransformSync.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.Components.Network.TransformSync.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(TransformSyncLogs))]
    public class TransformSyncLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}