using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Roll.Common
{
    public class PlayerRollRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name + "/";
        private const string Name = "Roll";

        public const string LocalName = PlayerAssetsPrefixes.Component + Name + "_Local";
        public const string LocalPath = Root + "Local";

        public const string RemoteName = PlayerAssetsPrefixes.Component + Name + "_Remote";
        public const string RemotePath = Root + "Remote";

        public const string DefinitionName = PlayerAssetsPrefixes.Definition + "Roll";
        public const string DefinitionPath = Root + "Definition";

        public const string AttackAnimationName = "Animation_Roll";
        public const string AttackAnimationPath = Root + "RollAnimation";

        public const string ConfigName = PlayerAssetsPrefixes.Config + Name;
        public const string ConfigPath = Root + "Config";
    }
}