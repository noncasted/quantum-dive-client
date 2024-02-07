using GamePlay.Enemy.Entity.Common.Routes;

namespace GamePlay.Enemy.Entity.Views.Animators.Common
{
    public class AnimatorRoutes
    {
        private const string _root = EnemyEntityRoutes.Views + _name + "/";
        private const string _name = "Animator";

        public const string LogsName = EnemyEntityPrefixes.Logs + _name;
        public const string LogsPath = _root + "Logs";
    }
}