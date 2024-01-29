using System;
using GamePlay.Common.Scope;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    public interface IEnemyDefinition
    {
        string Name { get; }
        int Id { get; }
        public EnemyObjectPools CreatePools(LevelScope scope, Func<string, Transform> createParent);
    }
}