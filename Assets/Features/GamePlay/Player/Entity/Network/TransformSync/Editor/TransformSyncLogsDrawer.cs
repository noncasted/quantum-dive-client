using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Network.TransformSync.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.Network.TransformSync.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(TransformSyncLogs))]
    public class TransformSyncLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}