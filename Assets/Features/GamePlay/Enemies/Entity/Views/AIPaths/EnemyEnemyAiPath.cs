﻿using Common.Architecture.Lifetimes;
using GamePlay.Enemies.Updater.Runtime;
using GamePlay.Enemies.Updater.Runtime.Updatables;
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
        private ILifetime _lifetime;
        
        public Vector2 NextPoint => _ai.steeringTarget;
        
        public void Follow(ISearchableTarget target)
        {
            _lifetime?.Terminate();
            _lifetime = new Lifetime();
            _updater.Add(_lifetime, this);
            
            _target = target;

            _ai.canMove = true;
 
            _ai.destination = target.Position;
            _ai.SearchPath();
        }

        public void Stop()
        {
            _lifetime.Terminate();
            _lifetime = null;
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