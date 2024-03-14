using GamePlay.Services.System.Ecs.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.Ecs.Runtime
{
    public class EcsSystemsHandler : IEcsSystemsHandler
    {
        public EcsSystemsHandler(EcsWorld world)
        {
            Update = new EcsSystems(world);
            FixedUpdate = new EcsSystems(world);
        }

        public EcsSystems Update { get; }
        public EcsSystems FixedUpdate { get; }
    }
}