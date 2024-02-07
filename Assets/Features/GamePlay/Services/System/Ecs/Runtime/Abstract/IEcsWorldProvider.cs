using Leopotam.EcsLite;

namespace GamePlay.System.Ecs.Runtime.Abstract
{
    public interface IEcsWorldProvider
    {
        EcsWorld World { get; }
    }
}