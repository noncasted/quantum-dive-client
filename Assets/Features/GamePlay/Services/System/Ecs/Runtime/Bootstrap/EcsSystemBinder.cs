using GamePlay.System.Ecs.Runtime.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.System.Ecs.Runtime.Bootstrap
{
    public class EcsSystemBinder : IEcsSystemBinder
    {
        public EcsSystemBinder(IEcsSystemsHandler systems)
        {
            _systems = systems;
        }

        private readonly IEcsSystemsHandler _systems;

        public void AddToUpdateSystems(IEcsRunSystem system)
        {
            _systems.Update.Add(system);
        }

        public void AddToFixedUpdateSystems(IEcsRunSystem system)
        {
            _systems.FixedUpdate.Add(system);
        }
    }
}