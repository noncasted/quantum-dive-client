using GamePlay.Projectiles.Common;
using GamePlay.Projectiles.Entity.Views.Facade;
using UnityEngine;

namespace GamePlay.Projectiles.Registry.Definition
{
    [CreateAssetMenu(fileName = ProjectilesRoutes.DefinitionName, menuName = ProjectilesRoutes.DefinitionPath)]
    public class ProjectileDefinition : ScriptableObject, IProjectileDefinition
    {
        [SerializeField] [Min(1)] private int _startupInstances;
        [SerializeField] private ProjectileView _prefab;



        public string Key => _prefab.name;
        public string Name => _prefab.name;
    
    }
}