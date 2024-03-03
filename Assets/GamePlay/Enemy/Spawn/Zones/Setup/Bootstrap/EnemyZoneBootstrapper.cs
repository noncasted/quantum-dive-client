using Common.Architecture.Container.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Spawn.Zones.SpawnPoints;
using GamePlay.Enemy.Spawn.Zones.Trigger;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GamePlay.Enemy.Spawn.Zones.Setup.Bootstrap
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(EnemyZoneScope))]
    public class EnemyZoneBootstrapper : MonoBehaviour
    {
        [SerializeField] private EnemyZoneTrigger _zoneTrigger;
        [SerializeField] private EnemySpawnPoints _spawnPoints;

        public async UniTask Build(LifetimeScope parent, ICallbackRegistry callbacks)
        {
            var scope = GetComponent<EnemyZoneScope>();

            using (LifetimeScope.EnqueueParent(parent))
            {
                using (LifetimeScope.Enqueue(Register))
                {
                    await UniTask.Create(async () => scope.Build());
                }
            }

            void Register(IContainerBuilder container)
            {
                container.RegisterComponent(_zoneTrigger)
                    .As<IEnemyZoneTrigger>();

                container.RegisterComponent(_spawnPoints)
                    .As<IEnemySpawnPoints>();
            }
        }
    }
}