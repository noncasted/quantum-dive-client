using System;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Pathfinding;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.AIPaths
{
    [Serializable]
    public class EnemyAIPathFactory : IComponentFactory
    {
        [SerializeField] private AIPath _ai;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            _ai.canMove = false;
            
            services.Register<EnemyEnemyAiPath>()
                .As<IEnemyAiFollower>()
                .WithParameter<IAstarAI>(_ai);
        }
    }
}