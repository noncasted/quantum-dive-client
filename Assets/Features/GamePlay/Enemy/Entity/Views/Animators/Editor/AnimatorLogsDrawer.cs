using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemies.Entity.Views.Animators.Logs;
using UnityEditor;

namespace GamePlay.Enemies.Entity.Views.Animators.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(AnimatorLogs))]
    public class AnimatorLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}