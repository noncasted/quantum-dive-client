using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.Floating.Common
{
    public class FloatingRoutes
    {
        private const string _root = PlayerAssetsPaths.States + _name;
        private const string _name = "Floating";

        public const string StateName = PlayerAssetsPrefixes.Component + _name;
        public const string StatePath = _root + "/State";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";
    }
}