using GamePlay.Enemy.Entity.Common.Routes;

namespace GamePlay.Enemy.Entity.Views.RigidBodies.Common
{
    public class RigidBodyRoutes
    {
        private const string _root = EnemyEntityRoutes.Views + _name;
        private const string _name = "RigidBody";

        public const string LogsName = EnemyEntityPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";
    }
}