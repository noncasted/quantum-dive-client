using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Setup.Root.Local;
using GamePlay.Enemies.Entity.Setup.Root.Remote;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;
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