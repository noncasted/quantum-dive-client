using GamePlay.System.Ecs.Runtime.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.System.Ecs.Runtime.Entities
{
    public class EntityComponentSetter : IEntityComponentSetter
    {
        public EntityComponentSetter(EcsWorld world)
        {
            _world = world;
        }

        private readonly EcsWorld _world;

        public ref T Add<T>(int entity) where T : struct
        {
            var pool = _world.GetPool<T>();
            ref var component = ref pool.Add(entity);

            return ref component;
        }

        public void Remove<T>(int entity) where T : struct
        {
            var pool = _world.GetPool<T>();
            pool.Del(entity);
        }
    }
}