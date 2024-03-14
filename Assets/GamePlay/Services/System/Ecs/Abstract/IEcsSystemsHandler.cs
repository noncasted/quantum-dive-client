using Leopotam.EcsLite;

namespace GamePlay.Ecs.Runtime.Abstract
{
    public interface IEcsSystemsHandler
    {
        EcsSystems Update { get; }
        EcsSystems FixedUpdate { get; }
    }
}