using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Network.EntityHandler;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.Setup.Root.Local;
using GamePlay.Enemies.Entity.Setup.Scope;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.Container.Runtime.ContainerBuilder;

namespace GamePlay.Enemies.Entity.Setup.Bootstrap.Local
{
    [SelectionBase]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(EnemyScope))]
    public class LocalEnemyBootstrapper : MonoBehaviour, ILocalEnemyBootstrapper
    {
        public async UniTask<ILocalEnemyRoot> Bootstrap(LifetimeScope parent)
        {
            var scope = GetComponent<EnemyScope>();
            var services = new ContainerBuilder();
            var eventLoop = new EnemyEventLoop();
            var builders = GetComponents<IEnemyContainerBuilder>();
            
            using (LifetimeScope.EnqueueParent(parent))
            {
                using (LifetimeScope.Enqueue(OnConfiguration))
                {
                    await UniTask.Create(async () => scope.Build());
                }
            }

            void OnConfiguration(IContainerBuilder container)
            {
                services.Register<LocalEnemyRoot>()
                    .As<ILocalEnemyRoot>()
                    .WithParameter<IEnemyEventLoop>(eventLoop)
                    .WithParameter(gameObject);

                services.Register<EntityProvider>()
                    .As<IEntityProvider>()
                    .As<IEntityEvents>()
                    .As<IPropertyBinder>();

                foreach (var target in builders)
                    target.OnBuild(services, eventLoop);

                services.RegisterAll(container);
            }

            services.ResolveAllWithCallbacks(scope.Container, eventLoop);

            var root = scope.Container.Resolve<ILocalEnemyRoot>();

            await root.OnBootstrapped();

            return root;
        }
    }
}