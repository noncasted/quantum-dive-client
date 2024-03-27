using GamePlay.Services.Projectiles.Common;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Systems.Sorting
{
    [InlineEditor]
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