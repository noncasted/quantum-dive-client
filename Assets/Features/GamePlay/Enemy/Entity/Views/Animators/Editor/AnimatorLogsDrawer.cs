using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemy.Entity.Views.Animators.Logs;
using UnityEditor;

namespace GamePlay.Enemy.Entity.Views.Animators.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(AnimatorLogs))]
    public class AnimatorLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}