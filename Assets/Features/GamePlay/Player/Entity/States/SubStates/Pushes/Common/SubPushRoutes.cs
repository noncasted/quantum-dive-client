using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Common
{
    public class SubPushRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name;
        private const string Name = "SubPush";

        public const string StateName = PlayerEntityPrefixes.Component + Name;
        public const string StatePath = Root + "/State";
    }
}