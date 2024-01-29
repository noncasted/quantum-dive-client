using Common.Architecture.Container.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Enemies.Spawn.Zones.SpawnPoints;
using GamePlay.Enemies.Spawn.Zones.Trigger;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GamePlay.Enemies.Spawn.Zones.Setup.Bootstrap
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(EnemyZoneScope))]
    public class EnemyZoneBootstrapper : SceneComponentBuilder
    {
        [SerializeField] private EnemyZoneTrigger _zoneTrigger;
        [SerializeField] private EnemySpawnPoints _spawnPoints;
        
        public override async UniTask Build(LifetimeScope parent, ICallbackRegister callbacks)
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