using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime;
using UnityEditor;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(BowPivotsDictionary))]
    public class BowPivotsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}