﻿using GamePlay.System.Ecs.Runtime.Abstract;
using Leopotam.EcsLite;

namespace GamePlay.System.Ecs.Runtime.Entities
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