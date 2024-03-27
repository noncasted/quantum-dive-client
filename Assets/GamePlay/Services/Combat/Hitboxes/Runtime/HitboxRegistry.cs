using System.Collections.Generic;
using GamePlay.Common.Damages;
using GamePlay.Services.Combat.Hitboxes.Abstract;
using GamePlay.Services.Hitboxes.Flags;
using GamePlay.Services.System.Ecs.Abstract;

namespace GamePlay.Services.Hitboxes.Runtime
{
    public class HitboxRegistry : IHitboxRegistry
    {
        public HitboxRegistry(
            IEntityCreator creator,
            IEntityComponentSetter componentSetter,
            IEntityDestroyer destroyer)
        {
            _creator = creator;
            _componentSetter = componentSetter;
            _destroyer = destroyer;
        }

        private readonly IEntityCreator _creator;
        private readonly IEntityComponentSetter _componentSetter;
        private readonly IEntityDestroyer _destroyer;

        private readonly Dictionary<IDamageReceiver, int> _entities = new();
        
        public void AddLocalPlayer(IDamageReceiver damageReceiver)
        {
            var entity = CreateHitbox(damageReceiver);
            _componentSetter.Add<PlayerFlag>(entity);
            _componentSetter.Add<LocalFlag>(entity);
        }

        public void AddRemotePlayer(IDamageReceiver damageReceiver)
        {
            var entity = CreateHitbox(damageReceiver);
            _componentSetter.Add<PlayerFlag>(entity);
            _componentSetter.Add<RemoteFlag>(entity);
        }

        public void AddEnemy(IDamageReceiver damageReceiver)
        {
            var entity = CreateHitbox(damageReceiver);

            _componentSetter.Add<EnemyFlag>(entity);
        }

        public void Remove(IDamageReceiver damageReceiver)
        {
            var entity = _entities[damageReceiver];

            _destroyer.Destroy(entity);
            _entities.Remove(damageReceiver);
        }

        private int CreateHitbox(IDamageReceiver damageReceiver)
        {
            var entity = _creator.CreateEntity();
            
            ref var hitbox = ref _componentSetter.Add<HitboxComponent>(entity);
            hitbox.Construct(damageReceiver);

            _entities.Add(damageReceiver, entity);

            return entity;
        }
    }
}