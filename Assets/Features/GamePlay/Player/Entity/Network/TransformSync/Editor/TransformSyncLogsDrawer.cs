using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Views.Transforms.Remote.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.Views.Transforms.Remote.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(TransformSyncLogs))]
    public class TransformSyncLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}