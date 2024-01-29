using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Scope;
using GamePlay.Enemies.Entity.Setup.Root.Local;
using GamePlay.Enemies.Entity.Setup.Root.Remote;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;
using GamePlay.Enemies.Services.Spawn.Registry.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Enemies.Services.Spawn.Pool.Runtime
{
    public class EnemyPool : IEnemyPool, IScopeAwakeListener, IScopeAwakeAsyncListener, IScopeDisableListener
    {
        public EnemyPool(
            LevelScope scope,
            Scene targetScene,
            IEnemyDefinitionsRegistry definitionsRegistry)
        {
            _scope = scope;
            _targetScene = targetScene;
            _definitionsRegistry = definitionsRegistry;
        }

        private readonly LevelScope _scope;
        private readonly Scene _targetScene;
        
        private readonly IEnemyDefinitionsRegistry _definitionsRegistry;

        private readonly List<IAsyncObjectsPool> _pools = new();
        
        private readonly Dictionary<IEnemyDefinition, IAsyncObjectProvider<ILocalEnemyRoot>> _localProviders = new();
        private readonly Dictionary<IEnemyDefinition, IAsyncObjectProvider<IRemoteEnemyRoot>> _remoteProviders = new();

        public void OnAwake()
        {
            foreach (var definition in _definitionsRegistry.Definitions)
            {
                var pools = definition.CreatePools(_scope, CreateParent);
                
                _pools.Add(pools.Local);
                _pools.Add(pools.Remote);
                _localProviders.Add(definition, pools.Local.GetProvider<ILocalEnemyRoot>());
                _remoteProviders.Add(definition, pools.Remote.GetProvider<IRemoteEnemyRoot>());
            }
        }
        
        public async UniTask OnAwakeAsync()
        {
            var tasks = new UniTask[_pools.Count];
            
            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = _pools[i].Preload();

            await UniTask.WhenAll(tasks);
        }
        
        public void OnDisabled()
        {
            foreach (var pool in _pools)
                pool.Unload();
        }
        
        public async UniTask<ILocalEnemyRoot> GetLocal(IEnemyDefinition definition, Vector2 position)
        {
            return await _localProviders[definition].Get(position);
        }

        public async UniTask<IRemoteEnemyRoot> GetRemote(IEnemyDefinition definition, Vector2 position)
        {
            return await _remoteProviders[definition].Get(position);
        }
        
        private Transform CreateParent(string assetName)
        {
            var root = new GameObject($"{assetName} objects")
            {
                transform =
                {
                    position = Vector3.zero
                }
            };

            SceneManager.MoveGameObjectToScene(root, _targetScene);

            return root.transform;
        }
    }
}