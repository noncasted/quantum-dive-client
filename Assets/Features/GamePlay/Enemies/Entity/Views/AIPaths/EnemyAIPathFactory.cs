using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using Pathfinding;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.AIPaths
{
    [Serializable]
    public class EnemyAIPathFactory : IComponentFactory
    {
        [SerializeField] private AIPath _ai;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            _ai.canMove = false;
            
            services.Register<EnemyEnemyAiPath>()
                .As<IEnemyAiFollower>()
                .WithParameter<IAstarAI>(_ai);
        }
    }
}