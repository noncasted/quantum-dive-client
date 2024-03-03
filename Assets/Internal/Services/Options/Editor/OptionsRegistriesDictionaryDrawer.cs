using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Internal.Options.Runtime;
using UnityEditor;

namespace Internal.Options.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(OptionsRegistriesDictionary))]
    public class OptionsRegistriesDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}