﻿using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime
{
    [DisallowMultipleComponent]
    public class EquipmentSlotView : MonoBehaviour
    {
        public void Attach(Transform equipment)
        {
            equipment.parent = transform;
            equipment.localPosition = Vector3.zero;
        }
    }
}