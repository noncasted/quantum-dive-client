using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Equipment.Equipper.Common
{
    public class EquipperRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + _name + "/";
        private const string _name = "Equipper";

        public const string LocalName = PlayerAssetsPrefixes.Component + _name + "_Local";
        public const string LocalPath = _root + "Local";
        
        public const string RemoteName = PlayerAssetsPrefixes.Component + _name + "_Remote";
        public const string RemotePath = _root + "Remote";
    }
}