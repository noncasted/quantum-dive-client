using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Scope;
using GamePlay.Enemies.Entity.Setup.Bootstrap.Local;
using GamePlay.Enemies.Entity.Setup.Root.Local;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    public class LocalEnemyObjectFactory : IAsyncObjectFactory<ILocalEnemyRoot>
    {
        public LocalEnemyObjectFactory(
            LocalEnemyBootstrapper prefab,
            LevelScope scope,
            Transform parent)
        {
            _prefab = prefab;
            _scope = scope;
            _parent = parent;
        }

        private readonly Transform _parent;
        private readonly LevelScope _scope;
        private readonly LocalEnemyBootstrapper _prefab;

        public async UniTask<ILocalEnemyRoot> Create(Vector2 position, float angle = 0)
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