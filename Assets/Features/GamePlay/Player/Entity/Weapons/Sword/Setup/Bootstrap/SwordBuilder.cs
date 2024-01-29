using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Abstract.Definition;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Setup.EventLoop;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.Common.Scope;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Root.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.Container.Runtime.ContainerBuilder;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Bootstrap
{
    [DisallowMultipleComponent]
    public class SwordBuilder : MonoBehaviour
    {
        public async UniTask<IEquipment> Build(LifetimeScope parent, SwordSlotDefinition definition)
        {
            var scope = GetComponent<SwordScope>();
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
                services.Register<SwordRoot>()
                    .WithParameter(definition)
                    .WithParameter<IPlayerObjectEventLoop>(flowHandler)
                    .AsSelf();

                var builders = GetComponents<IPlayerContainerBuilder>();

                foreach (var containerBuilder in builders)
                    containerBuilder.OnBuild(services, flowHandler);

                services.RegisterAll(container);
            }

            services.ResolveAllWithCallbacks(scope.Container, flowHandler);

            var root = scope.Container.Resolve<SwordRoot>();

            await root.OnBootstrapped();

            return root;
        }
    }
}