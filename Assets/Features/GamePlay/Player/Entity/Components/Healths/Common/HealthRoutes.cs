using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.Healths.Common
{
    public class HealthRoutes
    {
        private const string _root = PlayerAssetsPaths.Components + _name;
        private const string _name = "Health";

        public const string ComponentName = PlayerAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "/Component";
    }
}