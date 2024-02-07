using Common.Architecture.Scopes.Runtime.Callbacks;
using GamePlay.System.Ecs.Runtime.Abstract;
using GamePlay.System.Ecs.Runtime.Bootstrap;
using Global.System.MessageBrokers.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.System.Ecs.Runtime
{
    public class EcsHandler : IScopeLoadListener, IScopeDisableListener, IEcsWorldProvider
    {
        public EcsHandler(IUpdater updater, EcsWorld world)
        {
            _world = world;
            _systems = new EcsSystemsHandler(world);
            _updater = new EcsUpdater(updater, _systems);
        }

        private readonly EcsSystemsHandler _systems;
        private readonly EcsUpdater _updater;

        private readonly EcsWorld _world;

        public EcsWorld World => _world;

        public void OnLoaded()
        {
            var binder = new EcsSystemBinder(_systems);
            var bootstrapEvent = new EcsBootstrapEvent(binder);

            Msg.Publish(bootstrapEvent);

            _systems.Update.Init();
            _systems.FixedUpdate.Init();

            _updater.Start();
        }

        public void OnDisabled()
        {
            _updater.Stop();

            _systems.Update.Destroy();
            _systems.FixedUpdate.Destroy();

            _world.Destroy();
        }

        private void OnDestroy()
        {
            _updater?.Stop();

            _systems?.Update.Destroy();
            _systems?.FixedUpdate.Destroy();

            _world?.Destroy();
        }
    }
}