using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Cameras.Logs;
using UnityEditor;

namespace GamePlay.Cameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LevelCameraLogs))]
    public class LevelCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}