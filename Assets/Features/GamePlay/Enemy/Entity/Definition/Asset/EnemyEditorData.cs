﻿using GamePlay.Enemy.Entity.Definition.Asset.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Definition.Asset
{
    [InlineEditor]
    public class EnemyEditorData : ScriptableObject, IEnemyEditorData
    {
        [SerializeField] private Texture _editorIcon;

        public Texture EditorIcon => _editorIcon;
    }
}