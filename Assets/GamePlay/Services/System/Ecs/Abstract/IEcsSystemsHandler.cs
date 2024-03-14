using Leopotam.EcsLite;

namespace GamePlay.Services.System.Ecs.Abstract
{
    public interface IEcsSystemsHandler
    {
        EcsSystems Update { get; }
        EcsSystems FixedUpdate { get; }
    }
}