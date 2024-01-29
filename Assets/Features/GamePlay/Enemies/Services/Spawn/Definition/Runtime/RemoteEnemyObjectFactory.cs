using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Scope;
using GamePlay.Enemies.Entity.Setup.Bootstrap.Remote;
using GamePlay.Enemies.Entity.Setup.Root.Remote;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    public class RemoteEnemyObjectFactory : IAsyncObjectFactory<IRemoteEnemyRoot>
    {
        public RemoteEnemyObjectFactory(
            RemoteEnemyBootstrapper prefab,
            LevelScope scope,
            Transform parent)
        {
            _prefab = prefab;
            _scope = scope;
            _parent = parent;
        }

        private readonly Transform _parent;
        private readonly LevelScope _scope;
        private readonly RemoteEnemyBootstrapper _prefab;

        public async UniTask<IRemoteEnemyRoot> Create(Vector2 position, float angle = 0)
        {
            var bootstrapper = Object.Instantiate(
                _prefab,
                position,
                Quaternion.identity,
                _parent);

            var root = await bootstrapper.Bootstrap(_scope);

            return root;
        }
    }
}