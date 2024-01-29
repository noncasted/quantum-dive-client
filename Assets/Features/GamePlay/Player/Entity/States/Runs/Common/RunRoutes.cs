using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.Runs.Common
{
    public class RunRoutes
    {
        private const string _root = PlayerAssetsPaths.States + _name;
        private const string _name = "Run";

        public const string LocalName = PlayerAssetsPrefixes.Component + _name;
        public const string LocalPath = _root + "/Local";

        public const string RemoteName = PlayerAssetsPrefixes.Component + _name;
        public const string RemotePath = _root + "/Remote";
        
        public const string ConfigName = PlayerAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "/Config";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";
        
        public const string DefinitionName = PlayerAssetsPrefixes.Definition + _name;
        public const string DefinitionPath = _root + "/Definition";
        
        public const string RunAnimationName = "Animation_Run";
        public const string RunAnimationPath = _root + "/Animation/Run";
        
        public const string WalkAnimationName = "Animation_Walk";
        public const string WalkAnimationPath = _root + "/Animation/Walk";
    }
}