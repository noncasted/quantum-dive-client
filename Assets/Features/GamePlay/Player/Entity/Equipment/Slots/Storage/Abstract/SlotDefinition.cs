﻿using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract
{
    public abstract class SlotDefinition : ScriptableObject
    {
        [SerializeField] private string _name;

        public string Name => _name;
    }
}