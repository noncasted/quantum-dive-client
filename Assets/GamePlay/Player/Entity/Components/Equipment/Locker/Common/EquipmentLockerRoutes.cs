using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Equipment.Common;

namespace GamePlay.Player.Entity.Components.Equipment.Locker.Common
{
    public class EquipmentLockerRoutes
    {
        private const string Root = PlayerEquipmentRoutes.Root + Name + "/";
        private const string Name = "EquipmentLocker";

        public const string ComponentName = PlayerEntityPrefixes.Component + Name;
        public const string ComponentPath = Root + "Component";
    }
}