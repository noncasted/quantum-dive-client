using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using GamePlay.Player.Upgrades.Events;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ShotDelays
{
    public class ShotDelayData : IShotDelayData
    {
        public ShotDelayData(MultiplierEventListener<ShotDelayMultiplierEvent> multiplierListener)
        {
            multiplierListener.AddListener(AddMultiplier);
        }

        private readonly Multiplier _multiplier = new();

        private float _value = 1f;

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