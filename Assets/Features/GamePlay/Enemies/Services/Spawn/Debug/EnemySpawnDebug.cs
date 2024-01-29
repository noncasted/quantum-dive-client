using Common.Architecture.Container.Abstract;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;
using GamePlay.Enemies.Services.Spawn.Factory.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace GamePlay.Enemies.Services.Spawn.Debug
{
    [DisallowMultipleComponent]
    public class EnemySpawnDebug : SceneComponentRegister
    {
        [SerializeField] private Transform _point;
        [SerializeField] private EnemyDefinition _range;
        
        private IEnemyFactory _factory;

        [Inject]
        private void Construct(IEnemyFactory factory)
        {
            _factory = factory;
        }
        
        public override void Register(IServiceCollection services)
        {
            services.Inject(this);
        }

        [Button]
        private void SpawnRange()
        {
            _factory.CreateAsync(_range, _point.position);
        }
    }
}