using GamePlay.Enemy.Entity.Common.Routes;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Common
{
    public class TransformRoutes
    {
        private const string _root = EnemyEntityRoutes.Views + _name + "/";
        private const string _name = "Transform";

        public const string LogsName = EnemyEntityPrefixes.Logs + _name;
        public const string LogsPath = _root + "Logs";
    }
}