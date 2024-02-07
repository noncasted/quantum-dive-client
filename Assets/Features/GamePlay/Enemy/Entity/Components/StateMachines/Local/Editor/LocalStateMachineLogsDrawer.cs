using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemies.Entity.Components.StateMachines.Local.Logs;
using UnityEditor;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Local.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LocalStateMachineLogs))]
    public class LocalStateMachineLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}