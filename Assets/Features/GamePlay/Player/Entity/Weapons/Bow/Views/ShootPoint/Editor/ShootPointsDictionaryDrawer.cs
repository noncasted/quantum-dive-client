using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using UnityEditor;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ShootPointsDictionaryDrawer))]
    public class ShootPointsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}