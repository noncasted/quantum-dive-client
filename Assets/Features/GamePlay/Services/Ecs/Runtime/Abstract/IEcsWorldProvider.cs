using Leopotam.EcsLite;

namespace GamePlay.Ecs.Runtime.Abstract
{
    public interface IEcsWorldProvider
    {
        EcsWorld World { get; }
    }
}