﻿using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Common.Definition.Asset
{
    [InlineEditor]
    public class EnemyIdentification : ScriptableObject, IEnemyIdentification
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;

        public int Id => _id;
        public string Name => _name;
        
        public void SetId(int id)
        {
            _id = id;
        }
    }
}