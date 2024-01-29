using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using GamePlay.Player.Services.Upgrades.Events;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ProjectilesAmount
{
    public class ProjectilesAmountData : IProjectilesAmountData
    {
        public ProjectilesAmountData(
            AddEventListener<ProjectilesAmountAddEvent> addListener,
            MultiplierEventListener<ProjectilesAmountMultiplierEvent> multiplierListener)
        {
            addListener.AddListener(AddAmount);
            multiplierListener.AddListener(AddMultiplier);
        }

        private readonly Multiplier _multiplier = new();

        private int _value;

        public int Value => CalculateValue();

        public void SetValue(int value)
        {
            _value = value;
        }

        public void AddAmount(int amount)
        {
            _value += amount;
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