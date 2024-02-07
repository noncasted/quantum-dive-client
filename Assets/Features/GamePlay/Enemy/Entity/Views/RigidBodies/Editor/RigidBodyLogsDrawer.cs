using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemy.Entity.Views.RigidBodies.Logs;
using UnityEditor;

namespace GamePlay.Enemy.Entity.Views.RigidBodies.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(RigidBodyLogs))]
    public class RigidBodyLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}