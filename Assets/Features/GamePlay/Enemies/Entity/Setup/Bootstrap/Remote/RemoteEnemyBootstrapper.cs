using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Network.EntityHandler;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.Setup.Root.Remote;
using GamePlay.Enemies.Entity.Setup.Scope;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.Container.Runtime.ContainerBuilder;

namespace GamePlay.Enemies.Entity.Setup.Bootstrap.Remote
{
    [DisallowMultipleComponent]
    public class RemoteEnemyBootstrapper : MonoBehaviour, IRemoteEnemyBootstrapper
    {
        public async UniTask<IRemoteEnemyRoot> Bootstrap(LifetimeScope parent)
        {
            var scope = GetComponent<EnemyScope>();
            var services = new ContainerBuilder();
            var flowHandler = new EnemyEventLoop();
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
                services.Register<RemoteEnemyRoot>()
                    .As<IRemoteEnemyRoot>()
                    .WithParameter<IEnemyEventLoop>(flowHandler)
                    .WithParameter(gameObject);

                services.Register<EntityProvider>()
                    .As<IEntityProvider>()
                    .As<IEntityEvents>()
                    .As<IPropertyBinder>();
                
                foreach (var target in builders)
                    target.OnBuild(services, flowHandler);

                services.RegisterAll(container);
            }

            services.ResolveAllWithCallbacks(scope.Container, flowHandler);

            var root = scope.Container.Resolve<IRemoteEnemyRoot>();

            await root.OnBootstrapped();

            return root;
        }
    }
}