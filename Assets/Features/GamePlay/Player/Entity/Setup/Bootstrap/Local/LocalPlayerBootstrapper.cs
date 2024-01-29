using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Setup.EventLoop;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.Setup.Root.Local;
using GamePlay.Player.Entity.Setup.Scope;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.Container.Runtime.ContainerBuilder;

namespace GamePlay.Player.Entity.Setup.Bootstrap.Local
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerScope))]
    public class LocalPlayerBootstrapper : MonoBehaviour, ILocalPlayerBootstrapper
    {
        public async UniTask<IPlayerRoot> Bootstrap(LifetimeScope parent, PlayerAttachHandler entityHandler)
        {
            var scope = GetComponent<PlayerScope>();
            var services = new ContainerBuilder();
            var eventLoop = new PlayerEventLoop();

            using (LifetimeScope.EnqueueParent(parent))
            {
                using (LifetimeScope.Enqueue(OnConfiguration))
                {
                    await UniTask.Create(async () => scope.Build());
                }
            }

            void OnConfiguration(IContainerBuilder container)
            {
                services.Register<PlayerRoot>()
                    .As<IPlayerRoot>()
                    .WithParameter<IPlayerObjectEventLoop>(eventLoop);

                services.Register<ParentScopeProvider>()
                    .WithParameter(scope)
                    .As<IParentScopeProvider>();
                
                services.Register<EntityProvider>()
                    .As<IEntityProvider>()
                    .As<IEntityEvents>()
                    .As<IPropertyBinder>()
                    .WithParameter(entityHandler.Entity);

                var builders = GetComponents<IPlayerContainerBuilder>();

                foreach (var target in builders)
                    target.OnBuild(services, eventLoop);

                services.RegisterAll(container);
            }

            services.ResolveAllWithCallbacks(scope.Container, eventLoop);
            
            await entityHandler.SendToNetwork();

            var root = scope.Container.Resolve<IPlayerRoot>();

            await root.OnBootstrapped();

            return root;
        }
    }
}