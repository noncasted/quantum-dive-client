
using Global.System.MessageBrokers.Abstract;

namespace GamePlay.Player.Entity.Components.Healths.Runtime
{
    public class Health : IHealth
    {
        public Health(int start)
        {
            Construct(start);
        }

        private int _current;
        private int _max;

        public bool IsAlive => _current > 0;

        public void Construct(int max)
        {
            _max = max;
            _current = max;

            Msg.Publish(new PlayerHealthChangeEvent(max, max));
        }

        public void Heal(int heal)
        {
            _current += heal;

            if (_current > _max)
                _current = _max;

            Msg.Publish(new PlayerHealthChangeEvent(_max, _current));
        }

        public void AddMax(int add)
        {
            _max += add;

            Msg.Publish(new PlayerHealthChangeEvent(_max, _current));
        }

        public void ReduceMax(int reduce)
        {
            _max -= reduce;

            if (_max < 1)
                _max = 1;

            Msg.Publish(new PlayerHealthChangeEvent(_max, _current));
        }

        public void OnDamage(int damage)
        {
            _current -= damage;

            if (_current < 0)
                _current = 0;

            Msg.Publish(new PlayerHealthChangeEvent(_max, _current));
        }
    }
}