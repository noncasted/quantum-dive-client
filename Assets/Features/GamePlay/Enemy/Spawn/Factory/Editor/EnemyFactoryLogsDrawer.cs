using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemy.Spawn.Factory.Logs;
using UnityEditor;

namespace GamePlay.Enemy.Spawn.Factory.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(EnemyFactoryLogs))]
    public class EnemyFactoryLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}