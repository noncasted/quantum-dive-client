﻿using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Definition
{
    public interface IEquipment
    {
        SlotDefinition Slot { get; }
        Transform Transform { get; }
        UniTask Construct();
        UniTask Select();
        UniTask Deselect();
    }
}