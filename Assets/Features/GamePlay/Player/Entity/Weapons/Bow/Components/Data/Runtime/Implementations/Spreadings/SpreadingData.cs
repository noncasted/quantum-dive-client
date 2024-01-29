using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.Spreadings
{
    public class SpreadingData : ISpreadingData
    {
        private readonly Multiplier _multiplier = new();
        private float _value;

        public float Value => CalculateValue();

        public void SetValue(float value)
        {
            _value = value;
        }

        public void AddMultiplier(float multiplier)
        {
            _multiplier.Add(multiplier);
        }

        private int CalculateValue()
        {
            var result = Mathf.CeilToInt(_value * _multiplier.Calculate());

            return result;
        }
    }
}