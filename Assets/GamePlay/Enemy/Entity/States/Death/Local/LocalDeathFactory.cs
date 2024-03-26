using GamePlay.Enemy.Entity.States.Death.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Death.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDeathRoutes.LocalName,
        menuName = EnemyDeathRoutes.LocalPath)]
    public class LocalDeathFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private DeathDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalDeath>()
                .WithParameter(_definition)
                .As<IDeath>();
        }
    }
}