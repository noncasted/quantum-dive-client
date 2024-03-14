using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;
using GamePlay.Enemy.Entity.Common.Definition.Root;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Pool.Runtime
{
    public interface IEnemyPool
    {
        UniTask Preload();
        UniTask<ILocalEnemyRoot> GetLocal(IEnemyDefinition definition, Vector2 position, RagonEntity entity);
        UniTask<IRemoteEnemyRoot> GetRemote(IEnemyDefinition definition, RagonEntity entity);
    }
}