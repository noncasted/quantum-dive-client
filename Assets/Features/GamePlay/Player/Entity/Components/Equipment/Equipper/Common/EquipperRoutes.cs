using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Equipment.Common;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Common
{
    public class EquipperRoutes
    {
        private const string Root = PlayerEquipmentRoutes.Root + Name + "/";
        private const string Name = "Equipper";

        public const string LocalName = PlayerEntityPrefixes.Component + Name + "_Local";
        public const string LocalPath = Root + "Local";
        
        public const string RemoteName = PlayerEntityPrefixes.Component + Name + "_Remote";
        public const string RemotePath = Root + "Remote";
    }
}