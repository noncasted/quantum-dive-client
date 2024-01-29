using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Equipment.Slots.Binder.Common
{
    public class EquipmentBinderRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + _name + "/";
        private const string _name = "EquipmentBinder";

        public const string ComponentName = PlayerAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + _name + "/Component";
    }
}