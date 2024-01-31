using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Runs.Common
{
    public class RunRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name;
        private const string Name = "Run";

        public const string LocalName = PlayerAssetsPrefixes.Component + Name;
        public const string LocalPath = Root + "/Local";

        public const string RemoteName = PlayerAssetsPrefixes.Component + Name;
        public const string RemotePath = Root + "/Remote";
        
        public const string ConfigName = PlayerAssetsPrefixes.Config + Name;
        public const string ConfigPath = Root + "/Config";

        public const string LogsName = PlayerAssetsPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";
        
        public const string DefinitionName = PlayerAssetsPrefixes.Definition + Name;
        public const string DefinitionPath = Root + "/Definition";
        
        public const string RunAnimationName = "Animation_Run";
        public const string RunAnimationPath = Root + "/Animation/Run";
        
        public const string WalkAnimationName = "Animation_Walk";
        public const string WalkAnimationPath = Root + "/Animation/Walk";
    }
}