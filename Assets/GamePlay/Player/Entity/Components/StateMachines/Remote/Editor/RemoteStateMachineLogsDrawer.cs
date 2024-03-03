using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Logs;
using UnityEditor;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(RemoteStateMachineLogs))]
    public class RemoteStateMachineLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}