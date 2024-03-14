using Leopotam.EcsLite;

namespace GamePlay.Services.System.Ecs.Abstract
{
    public interface IEcsWorldProvider
    {
        EcsWorld World { get; }
    }
}