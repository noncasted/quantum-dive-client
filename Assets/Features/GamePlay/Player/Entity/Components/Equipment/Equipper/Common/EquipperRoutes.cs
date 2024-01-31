using GamePlay.Player.Entity.Components.Equipment.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Common
{
    public class EquipperRoutes
    {
        private const string Root = PlayerEquipmentRoutes.Root + Name + "/";
        private const string Name = "Equipper";

        public const string LocalName = PlayerAssetsPrefixes.Component + Name + "_Local";
        public const string LocalPath = Root + "Local";
        
        public const string RemoteName = PlayerAssetsPrefixes.Component + Name + "_Remote";
        public const string RemotePath = Root + "Remote";
    }
}