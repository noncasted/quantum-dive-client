﻿using GamePlay.Enemy.Entity.Definition.Asset.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Definition.Asset
{
    [InlineEditor]
    public abstract class EnemyDefinition : ScriptableObject, IEnemyDefinition
    {
        public abstract IEnemyIdentification Identification { get; }
        public abstract IEnemyConfiguration Configuration { get; }
        public abstract IEnemyEditorData EditorData { get; }
    }
}