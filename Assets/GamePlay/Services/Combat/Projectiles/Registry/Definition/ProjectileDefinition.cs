using GamePlay.Services.Projectiles.Common;
using GamePlay.Services.Projectiles.Entity.Views.Facade;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Registry.Definition
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