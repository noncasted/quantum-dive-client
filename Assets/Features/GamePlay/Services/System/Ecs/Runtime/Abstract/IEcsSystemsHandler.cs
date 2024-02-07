using Leopotam.EcsLite;

namespace GamePlay.System.Ecs.Runtime.Abstract
{
    public interface IEcsSystemsHandler
    {
        EcsSystems Update { get; }
        EcsSystems FixedUpdate { get; }
    }
}