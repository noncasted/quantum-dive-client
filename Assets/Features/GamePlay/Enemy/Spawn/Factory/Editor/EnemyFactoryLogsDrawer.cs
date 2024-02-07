using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemies.Spawn.Factory.Logs;
using UnityEditor;

namespace GamePlay.Enemies.Spawn.Factory.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(EnemyFactoryLogs))]
    public class EnemyFactoryLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}