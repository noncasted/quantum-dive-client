using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Common
{
    public class SubPushRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + _name;
        private const string _name = "SubPush";

        public const string StateName = PlayerAssetsPrefixes.Component + _name;
        public const string StatePath = _root + "/State";
    }
}