using GamePlay.Services.System.Ecs.Abstract;
using Global.System.Updaters.Abstract;

namespace GamePlay.Services.Ecs.Runtime
{
    public class EcsUpdater : IUpdatable, IFixedUpdatable
    {
        public EcsUpdater(
            IUpdater updater,
            IEcsSystemsHandler systems)
        {
            _updater = updater;
            _systems = systems;
        }

        private readonly IEcsSystemsHandler _systems;

        private readonly IUpdater _updater;

        public void OnFixedUpdate(float delta)
        {
            _systems.FixedUpdate.Run();
        }

        public void OnUpdate(float delta)
        {
            _systems.Update.Run();
        }

        public void Start()
        {
            _updater.Add((IUpdatable)this);
            _updater.Add((IFixedUpdatable)this);
        }

        public void Stop()
        {
            _updater.Remove((IUpdatable)this);
            _updater.Remove((IFixedUpdatable)this);
        }
    }
}