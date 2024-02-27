using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract
{
    public abstract class SlotDefinition : ScriptableObject
    {
        public abstract string Name { get; }
    }
}