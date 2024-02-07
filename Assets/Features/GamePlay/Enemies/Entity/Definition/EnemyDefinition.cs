using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    [InlineEditor]
    public abstract class EnemyDefinition : ScriptableObject, IEnemyDefinition
    {
        public abstract IEnemyIdentification Identification { get; }
        public abstract IEnemyConfiguration Configuration { get; }
        public abstract IEnemyEditorData EditorData { get; }
    }
}