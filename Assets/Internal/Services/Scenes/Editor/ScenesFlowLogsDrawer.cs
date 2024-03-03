using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Internal.Scenes.Logs;
using UnityEditor;

namespace Internal.Scenes.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ScenesFlowLogs))]
    public class ScenesFlowLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}