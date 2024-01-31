using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Respawns.Common
{
    public class RespawnRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name;
        private const string Name = "Respawn";

        public const string LocalName = PlayerAssetsPrefixes.Component + Name + "_Local";
        public const string LocalPath = Root + "/Local";
        
        public const string RemoteName = PlayerAssetsPrefixes.Component + Name + "_Remote";
        public const string RemotePath = Root + "/Remote";

        public const string LogsName = PlayerAssetsPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";
        
        public const string DefinitionName = PlayerAssetsPrefixes.Definition + Name;
        public const string DefinitionPath = Root + "/Definition";
        
        public const string AnimationName = "Animation_Respawn";
        public const string AnimationPath = Root + "/Animation";
    }
}