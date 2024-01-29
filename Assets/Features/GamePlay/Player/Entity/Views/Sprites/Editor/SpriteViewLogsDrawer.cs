using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Views.Sprites.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.Views.Sprites.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(SpriteLogs))]
    public class SpriteViewLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}