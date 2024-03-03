using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Common
{
    public class RotationRoutes
    {
        private const string _root = BowAssetsPaths.Root + _name + "/";
        private const string _name = "Rotation";

        public const string LocalName = BowAssetsPrefixes.Component + _name + "_Local";
        public const string LocalPath = _root + "Local";
        
        public const string RemoteName = BowAssetsPrefixes.Component + _name + "_Remote";
        public const string RemotePath = _root + "Remote";
        
        public const string ConfigName = BowAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "Config";
    }
}