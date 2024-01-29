using System;
using Common.Tools.ObjectsPools.Runtime;
using GamePlay.Common.Scope;
using GamePlay.Enemies.Entity.Setup.Bootstrap.Local;
using GamePlay.Enemies.Entity.Setup.Bootstrap.Remote;
using GamePlay.Enemies.Entity.Setup.Root.Local;
using GamePlay.Enemies.Entity.Setup.Root.Remote;
using GamePlay.Enemies.Services.Spawn.Definition.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDefinitionRoutes.Name,
        menuName = EnemyDefinitionRoutes.Path)]
    public class EnemyDefinition : ScriptableObject, IEnemyDefinition
    {
        [SerializeField] [ReadOnly] private int _id;
        [SerializeField] private string _name;
        
        [SerializeField] [Min(0)] private int _startupInstances;
        
        [SerializeField] private Texture _editorIcon;
        
        [SerializeField] private LocalEnemyBootstrapper _localPrefab;
        [SerializeField] private RemoteEnemyBootstrapper _remotePrefab;

        public Texture EditorIcon => _editorIcon;

        public string Name => _name;
        public int Id => _id;

        public void Construct(int id)
        {
            _id = id;
        }

        public EnemyObjectPools CreatePools(LevelScope scope, Func<string, Transform> createParent)
        {
            var localParent = createParent?.Invoke(_localPrefab.name);
            var localFactory = new LocalEnemyObjectFactory(_localPrefab, scope, localParent);
            var localPool = new AsyncObjectProvider<ILocalEnemyRoot>(localFactory, _startupInstances, localParent);
            
            var remoteParent = createParent?.Invoke(_remotePrefab.name);
            var remoteFactory = new RemoteEnemyObjectFactory(_remotePrefab, scope, remoteParent);
            var remotePool = new AsyncObjectProvider<IRemoteEnemyRoot>(remoteFactory, _startupInstances, remoteParent);

            var pools = new EnemyObjectPools(localPool, remotePool);
            
            return pools;
        }
    }
}