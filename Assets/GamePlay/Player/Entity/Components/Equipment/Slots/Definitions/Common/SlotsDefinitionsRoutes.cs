using GamePlay.Player.Entity.Components.Equipment.Common;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Common
{
    public class SlotsDefinitionsRoutes
    {
        private const string Root = PlayerEquipmentRoutes.Root + "Slots";

        public const string PrimaryName = "PlayerWeaponSlot_Primary";
        public const string PrimaryPath = Root + "/Primary";
        
        public const string SecondaryName = "PlayerWeaponSlot_Secondary";
        public const string SecondaryPath = Root + "/Secondary";
    }
}