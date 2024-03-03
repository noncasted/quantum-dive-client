using Common.Architecture.Container.Abstract;
using GamePlay.Enemy.Entity.Common.Definition.Asset;
using GamePlay.Enemy.Spawn.Factory.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace GamePlay.Enemy.Spawn.Debug
{
    [DisallowMultipleComponent]
    public class EnemySpawnDebug : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField] private EnemyDefinition _range;
        
        private IEnemyFactory _factory;

        [Inject]
        private void Construct(IEnemyFactory factory)
        {
            _factory = factory;
        }
        
        public void Register(IServiceCollection services)
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