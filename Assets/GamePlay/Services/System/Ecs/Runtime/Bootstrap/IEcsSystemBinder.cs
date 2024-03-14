using Leopotam.EcsLite;

namespace GamePlay.Ecs.Runtime.Bootstrap
{
    public interface IEcsSystemBinder
    {
        void AddToUpdateSystems(IEcsRunSystem system);
        void AddToFixedUpdateSystems(IEcsRunSystem system);
    }
}