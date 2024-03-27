using Common.DataTypes.Runtime.Reactive;
using GamePlay.Enemy.Entity.Components.Healths.Abstract;
using GamePlay.Enemy.Entity.Components.Network.EntityHandler.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.Components.Healths.Runtime
{
    public class Health : RagonProperty, IHealth
    {
        protected Health(IEntityProvider entity, IHealthConfig config) : base(0, false)
        {
            _entity = entity;
            _config = config;
        }

        private readonly IEntityProvider _entity;
        private readonly IHealthConfig _config;

        private int _current;
        private int _max;

        private readonly ViewableDelegate<int, int> _healthChanged = new();
        public IViewableDelegate<int, int> HealthChanged => _healthChanged;
        public int Amount => _current;
        public bool IsAlive => _current > 0;

        public void Remove(int amount)
        {
            _current -= amount;

            if (_current < 0)
                _current = 0;

            _healthChanged.Invoke(_current, _max);
            MarkAsChanged();
        }

        public void Restore()
        {
            _current = _config.Max;
            _max = _config.Max;
            _healthChanged.Invoke(_current, _max);
            MarkAsChanged();
        }

        public override void Serialize(RagonBuffer buffer)
        {
            buffer.WriteInt(_current, 0, 1024);
            buffer.WriteInt(_max, 0, 1024);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var current = buffer.ReadInt(0, 1024);
            var max = buffer.ReadInt(0, 1024);

            if (_entity.IsMine == true)
                return;

            _healthChanged?.Invoke(current, max);
        }
    }
}