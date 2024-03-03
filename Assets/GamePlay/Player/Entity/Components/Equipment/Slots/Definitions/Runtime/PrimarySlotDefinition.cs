using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(menuName = SlotsDefinitionsRoutes.PrimaryPath, fileName = SlotsDefinitionsRoutes.PrimaryName)]
    public class PrimarySlotDefinition : SlotDefinition
    {
        public override string Name => "Primary";
    }
}