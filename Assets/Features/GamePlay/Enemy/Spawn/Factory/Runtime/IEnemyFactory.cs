using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Definition.Asset.Abstract;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Factory.Runtime
{
    public interface IEnemyFactory
    {
        UniTask CreateAsync(IEnemyDefinition definition, Vector2 position);
    }
}