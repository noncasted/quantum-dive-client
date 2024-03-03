using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Visuals.Cameras.Logs;
using UnityEditor;

namespace GamePlay.Visuals.Cameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LevelCameraLogs))]
    public class LevelCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}