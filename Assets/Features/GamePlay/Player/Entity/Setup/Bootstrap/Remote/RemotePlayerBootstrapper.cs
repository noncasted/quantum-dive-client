using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Setup.EventLoop;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.Setup.Root.Remote;
using GamePlay.Player.Entity.Setup.Scope;
using Ragon.Client;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.Container.Runtime.ContainerBuilder;

namespace GamePlay.Player.Entity.Setup.Bootstrap.Remote
{
    [DisallowMultipleComponent]
    public class RemotePlayerBootstrapper : MonoBehaviour, IRemotePlayerBootstrapper
    {
        public async UniTask<IRemotePlayerRoot> Bootstrap(LifetimeScope parent, RagonEntity entity)
        {
            var scope = GetComponent<PlayerScope>();
            var services = new ContainerBuilder();
            var flowHandler = new PlayerEventLoop();

            using (LifetimeScope.EnqueueParent(parent))
            {
                using (LifetimeScope.Enqueue(OnConfiguration))
                {
                    await UniTask.Create(async () => scope.Build());
                }
            }

            void OnConfiguration(IContainerBuilder container)
            {
                services.Register<RemotePlayerRoot>()
                    .As<IRemotePlayerRoot>()
                    .WithParameter<IPlayerObjectEventLoop>(flowHandler);

                services.Register<ParentScopeProvider>()
                    .WithParameter(scope)
                    .As<IParentScopeProvider>();

                services.Register<EntityProvider>()
                    .As<IEntityProvider>()
                    .As<IEntityEvents>()
                    .As<IPropertyBinder>()
                    .WithParameter(entity);
                
                var builders = GetComponents<IPlayerContainerBuilder>();

                foreach (var target in builders)
                    target.OnBuild(services, flowHandler);

                services.RegisterAll(container);
            }

            services.ResolveAllWithCallbacks(scope.Container, flowHandler);

            var root = scope.Container.Resolve<IRemotePlayerRoot>();
            await root.OnBootstrapped();

            return root;
        }
    }
}