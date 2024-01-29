using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Common
{
    public class DamagedRoutes
    {
        private const string _root = PlayerAssetsPaths.States + _name;
        private const string _name = "Damaged";

        public const string LocalName = PlayerAssetsPrefixes.State + _name + "_Local";
        public const string LocalPath = _root + "/Local";

        public const string RemoteName = PlayerAssetsPrefixes.State + _name + "_Remote";
        public const string RemotePath = _root + "/Remote";

        public const string ConfigName = PlayerAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "/Config";
    }
}