using GamePlay.Services.System.Ecs.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.Ecs.Runtime.Entities
{
    public class EntityDestroyer : IEntityDestroyer
    {
        public EntityDestroyer(EcsWorld world)
        {
            _world = world;
        }

        private readonly EcsWorld _world;

        public void Destroy(int entity)
        {
            _world.DelEntity(entity);
        }
    }
}