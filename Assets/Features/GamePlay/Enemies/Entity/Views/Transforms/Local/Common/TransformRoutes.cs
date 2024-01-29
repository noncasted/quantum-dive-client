using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Views.Transforms.Local.Common
{
    public class TransformRoutes
    {
        private const string _root = EnemyAssetsPaths.Views + _name + "/";
        private const string _name = "Transform";

        public const string LogsName = EnemyAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "Logs";
    }
}