using GamePlay.Services.System.Ecs.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.Services.Ecs.Runtime.Entities
{
    public class EntityCreator : IEntityCreator
    {
        public EntityCreator(EcsWorld world)
        {
            _world = world;
        }

        private readonly EcsWorld _world;

        public int CreateEntity()
        {
            return _world.NewEntity();
        }
    }
}