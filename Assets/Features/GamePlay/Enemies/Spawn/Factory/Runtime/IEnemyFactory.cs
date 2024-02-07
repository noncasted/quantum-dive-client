using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Definition.Asset.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Spawn.Factory.Runtime
{
    public interface IEnemyFactory
    {
        UniTask CreateAsync(IEnemyDefinition definition, Vector2 position);
    }
}