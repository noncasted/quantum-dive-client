using GamePlay.System.Ecs.Runtime.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.System.Ecs.Runtime.Entities
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