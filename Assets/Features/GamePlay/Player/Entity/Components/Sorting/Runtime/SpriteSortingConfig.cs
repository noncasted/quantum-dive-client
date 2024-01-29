using GamePlay.Player.Entity.Components.Sorting.Common;
using NaughtyAttributes;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Sorting.Runtime
{
    [CreateAssetMenu(fileName = SortingRoutes.ConfigName,
        menuName = SortingRoutes.ConfigPath)]
    public class SpriteSortingConfig : ScriptableObject
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