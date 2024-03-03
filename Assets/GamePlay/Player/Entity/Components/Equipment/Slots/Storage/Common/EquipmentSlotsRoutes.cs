using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Equipment.Common;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Common
{
    public class EquipmentSlotsRoutes
    {
        private const string Root = PlayerEquipmentRoutes.Root + Name;
        private const string Name = "SlotsStorage";

        public const string ComponentName = PlayerEntityPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";
    }
}