using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemy.Entity.Components.StateMachines.Local.Logs;
using UnityEditor;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Local.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LocalStateMachineLogs))]
    public class LocalStateMachineLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}