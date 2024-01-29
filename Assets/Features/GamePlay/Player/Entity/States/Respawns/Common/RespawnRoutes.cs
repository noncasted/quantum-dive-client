using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.Respawns.Common
{
    public class RespawnRoutes
    {
        private const string _root = PlayerAssetsPaths.States + _name;
        private const string _name = "Respawn";

        public const string LocalName = PlayerAssetsPrefixes.Component + _name + "_Local";
        public const string LocalPath = _root + "/Local";
        
        public const string RemoteName = PlayerAssetsPrefixes.Component + _name + "_Remote";
        public const string RemotePath = _root + "/Remote";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";
        
        public const string DefinitionName = PlayerAssetsPrefixes.Definition + _name;
        public const string DefinitionPath = _root + "/Definition";
        
        public const string AnimationName = "Animation_Respawn";
        public const string AnimationPath = _root + "/Animation";
    }
}