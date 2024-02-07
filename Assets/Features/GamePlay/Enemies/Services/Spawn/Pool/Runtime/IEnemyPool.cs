using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Definition.Asset.Abstract;
using GamePlay.Enemies.Entity.Definition.Root;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Pool.Runtime
{
    public interface IEnemyPool
    {
        UniTask Preload();
        UniTask<ILocalEnemyRoot> GetLocal(IEnemyDefinition definition, Vector2 position, RagonEntity entity);
        UniTask<IRemoteEnemyRoot> GetRemote(IEnemyDefinition definition, RagonEntity entity);
    }
}