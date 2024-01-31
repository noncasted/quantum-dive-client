using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Binder
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