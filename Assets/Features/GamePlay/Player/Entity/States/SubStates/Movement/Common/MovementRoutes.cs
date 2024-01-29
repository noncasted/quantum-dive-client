using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.SubStates.Movement.Common
{
    public class MovementRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + _name;
        private const string _name = "SubMovement";

        public const string StateName = PlayerAssetsPrefixes.Component + _name;
        public const string StatePath = _root + "/State";
    }
}