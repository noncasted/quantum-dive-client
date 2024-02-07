using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Common
{
    public class DamagedRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name;
        private const string Name = "Damaged";

        public const string LocalName = PlayerEntityPrefixes.State + Name + "_Local";
        public const string LocalPath = Root + "/Local";

        public const string RemoteName = PlayerEntityPrefixes.State + Name + "_Remote";
        public const string RemotePath = Root + "/Remote";

        public const string ConfigName = PlayerEntityPrefixes.Config + Name;
        public const string ConfigPath = Root + "/Config";
    }
}