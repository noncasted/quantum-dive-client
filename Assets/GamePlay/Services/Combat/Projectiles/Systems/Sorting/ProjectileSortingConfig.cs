﻿using GamePlay.Combat.Projectiles.Common;
using NaughtyAttributes;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Systems.Sorting
{
    [CreateAssetMenu(fileName = ProjectilesRoutes.SortingConfigName,
        menuName = ProjectilesRoutes.SortingConfigPath)]
    public class ProjectileSortingConfig : ScriptableObject
    {
        [SerializeField] [SortingLayer] private string _behindWall;
        [SerializeField] [SortingLayer] private string _frontWall;
        
        [SerializeField] private LayerMask _checkLayer;
        [SerializeField] private float _rayDistance;
        
        public string BehindWall => _behindWall;
        public string FrontWall => _frontWall;
        
        public LayerMask CollisionLayer => _checkLayer;
        public float RayDistance => _rayDistance;
    }
}