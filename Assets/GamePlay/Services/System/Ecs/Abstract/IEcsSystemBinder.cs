using Leopotam.EcsLite;

namespace GamePlay.Services.System.Ecs.Abstract
{
    public interface IEcsSystemBinder
    {
        void AddToUpdateSystems(IEcsRunSystem system);
        void AddToFixedUpdateSystems(IEcsRunSystem system);
    }
}