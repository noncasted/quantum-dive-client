using GamePlay.Enemies.Services.Updater.Runtime;
using GamePlay.Enemies.Services.Updater.Runtime.Updatables;
using GamePlay.Targets.Registry.Runtime;
using Pathfinding;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.AIPaths
{
    public class EnemyEnemyAiPath : IEnemyAiFollower, IEnemyPathRecalculateUpdatable
    {
        public EnemyEnemyAiPath(
            IAstarAI ai,
            IEnemyUpdater updater)
        {
            _ai = ai;
            _updater = updater;
        }
        
        private readonly IAstarAI _ai;
        private readonly IEnemyUpdater _updater;

        private ISearchableTarget _target;
        
        public Vector2 NextPoint => _ai.steeringTarget;
        
        public void Follow(ISearchableTarget target)
        {
            _updater.Add(this);
            
            _target = target;

            _ai.canMove = true;
 
            _ai.destination = target.Position;
            _ai.SearchPath();
        }

        public void Stop()
        {
            _updater.Remove(this);
            _ai.canMove = false;
        }

        public void OnPathRecalculation()
        {
            if (_ai.pathPending == true)
                return;
            
            _ai.destination = _target.Position;
            _ai.SearchPath();
        }
    }
}