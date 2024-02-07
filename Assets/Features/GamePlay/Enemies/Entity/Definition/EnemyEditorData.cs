using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    [InlineEditor]
    public class EnemyEditorData : ScriptableObject, IEnemyEditorData
    {
        [SerializeField] private Texture _editorIcon;

        public Texture EditorIcon => _editorIcon;
    }
}