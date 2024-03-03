using GamePlay.Combat.Projectiles.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Systems.CollisionDetection
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ProjectilesRoutes.CollisionConfigName,
        menuName = ProjectilesRoutes.CollisionConfigPath)]
    public class ProjectilesCollisionDetectionConfigAsset : ScriptableObject
    {
        [SerializeField] [Indent] private LayerMask _collisionLayer;

        public LayerMask CollisionLayer => _collisionLayer;
    }
}