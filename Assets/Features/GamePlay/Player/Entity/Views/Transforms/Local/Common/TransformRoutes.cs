using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Views.Transforms.Local.Common
{
    public class TransformRoutes
    {
        private const string _root = PlayerAssetsPaths.Views + _name + "/";
        private const string _name = "Transform";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "Logs";
    }
}