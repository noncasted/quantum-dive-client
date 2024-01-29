using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemies.Entity.Views.Transforms.Remote.Logs;
using UnityEditor;

namespace GamePlay.Enemies.Entity.Views.Transforms.Remote.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(TransformSyncLogs))]
    public class TransformSyncLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}