using Common.DataTypes.Editor.Collections;
using Global.Inputs.Constranits.Abstract;
using UnityEditor;

namespace Global.Inputs.Constranits.Editor
{
    [CustomPropertyDrawer(typeof(InputConstraintsDictionary))]
    public class InputConstraintsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}