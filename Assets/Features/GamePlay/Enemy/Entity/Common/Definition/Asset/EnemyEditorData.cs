using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Common.Definition.Asset
{
    [InlineEditor]
    public class EnemyEditorData : ScriptableObject, IEnemyEditorData
    {
        [SerializeField] private Texture _editorIcon;

        public Texture EditorIcon => _editorIcon;
    }
}