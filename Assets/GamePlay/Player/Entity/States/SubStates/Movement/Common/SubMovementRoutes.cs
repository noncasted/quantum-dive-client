using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.SubStates.Movement.Common
{
    public class SubMovementRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name;
        private const string Name = "SubMovement";

        public const string StateName = PlayerEntityPrefixes.Component + Name;
        public const string StatePath = Root + "/State";
    }
}