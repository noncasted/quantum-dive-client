using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Equipment.Locker.Common
{
    public class EquipmentLockerRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + _name + "/";
        private const string _name = "EquipmentLocker";

        public const string ComponentName = PlayerAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "Component";
    }
}