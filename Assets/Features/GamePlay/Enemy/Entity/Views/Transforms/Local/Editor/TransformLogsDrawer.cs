﻿using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Logs;
using UnityEditor;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(TransformLogs))]
    public class TransformLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}