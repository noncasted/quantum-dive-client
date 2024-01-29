using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Views.Animators.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.Views.Animators.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(AnimatorLogs))]
    public class AnimatorLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}