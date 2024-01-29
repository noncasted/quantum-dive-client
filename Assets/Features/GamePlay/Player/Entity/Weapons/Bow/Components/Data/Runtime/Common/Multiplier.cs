using System.Collections.Generic;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common
{
    public class Multiplier
    {
        private readonly List<float> _values = new();

        public void Add(float value)
        {
            _values.Add(value);
        }

        public float Calculate()
        {
            var multiplier = 1f;

            foreach (var value in _values)
                multiplier += value;

            return multiplier;
        }
    }
}