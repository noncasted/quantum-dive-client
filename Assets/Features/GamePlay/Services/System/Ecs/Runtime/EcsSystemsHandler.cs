using GamePlay.System.Ecs.Runtime.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.System.Ecs.Runtime
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