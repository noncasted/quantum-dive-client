using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Roll.Common
{
    public class PlayerRollRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name + "/";
        private const string Name = "Roll";

        public const string LocalName = PlayerEntityPrefixes.Component + Name + "_Local";
        public const string LocalPath = Root + "Local";

        public const string RemoteName = PlayerEntityPrefixes.Component + Name + "_Remote";
        public const string RemotePath = Root + "Remote";

        public const string DefinitionName = PlayerEntityPrefixes.Definition + "Roll";
        public const string DefinitionPath = Root + "Definition";

        public const string AttackAnimationName = "Animation_Roll";
        public const string AttackAnimationPath = Root + "RollAnimation";

        public const string ConfigName = PlayerEntityPrefixes.Config + Name;
        public const string ConfigPath = Root + "Config";
    }
}