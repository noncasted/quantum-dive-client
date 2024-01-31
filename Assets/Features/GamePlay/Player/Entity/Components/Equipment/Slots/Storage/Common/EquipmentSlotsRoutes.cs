using GamePlay.Player.Entity.Components.Equipment.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Common
{
    public class EquipmentSlotsRoutes
    {
        private const string Root = PlayerEquipmentRoutes.Root + Name;
        private const string Name = "EquipmentSlots";

        public const string ComponentName = PlayerAssetsPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";
    }
}