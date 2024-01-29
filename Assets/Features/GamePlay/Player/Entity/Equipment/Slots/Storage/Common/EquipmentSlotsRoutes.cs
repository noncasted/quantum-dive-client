using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Equipment.Slots.Storage.Common
{
    public class EquipmentSlotsRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + _name;
        private const string _name = "EquipmentSlots";

        public const string ComponentName = PlayerAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "/Component";
    }
}