using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Definition.Asset;
using GamePlay.Enemies.Spawn.Factory.Runtime;
using GamePlay.Targets.Registry.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace GamePlay.Enemies.Tests.States
{
    [DisallowMultipleComponent]
    public class EnemyStatesTestRunner : MonoBehaviour
    {
        [Inject]
        private void Construct(
            IEnemyFactory factory,
            ITargetPlayerRegistry targetPlayerRegistry)
        {
            _targetPlayerRegistry = targetPlayerRegistry;
            _factory = factory;
        }

        [SerializeField] private EnemyDefinition _enemyDefinition;
        [SerializeField] private TestTargetPlayer _targetPrefab;
        
        private IEnemyFactory _factory;
        private ITargetPlayerRegistry _targetPlayerRegistry;

        public void Run()
        {
            
        }

        [Button]
        private void CreateEnemy()
        {
            _factory.CreateAsync(_enemyDefinition, Vector2.zero).Forget();
        }

        [Button]
        private void CreateTarget()
        {
            var target = Instantiate(_targetPrefab, new Vector3(5, 0), Quaternion.identity);
            _targetPlayerRegistry.AddPlayer(target);
        }
    }
}