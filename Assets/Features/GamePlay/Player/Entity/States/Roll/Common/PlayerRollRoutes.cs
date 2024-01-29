using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.Roll.Common
{
    public class PlayerRollRoutes
    {
        private const string _root = PlayerAssetsPaths.States + _name + "/";
        private const string _name = "Roll";

        public const string LocalName = PlayerAssetsPrefixes.Component + _name + "_Local";
        public const string LocalPath = _root + "Local";

        public const string RemoteName = PlayerAssetsPrefixes.Component + _name + "_Remote";
        public const string RemotePath = _root + "Remote";

        public const string DefinitionName = PlayerAssetsPrefixes.Definition + "Roll";
        public const string DefinitionPath = _root + "Definition";

        public const string AttackAnimationName = "Animation_Roll";
        public const string AttackAnimationPath = _root + "RollAnimation";

        public const string ConfigName = PlayerAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "Config";
    }
}