using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Views.Animators.Common
{
    public class AnimatorRoutes
    {
        private const string _root = EnemyAssetsPaths.Views + _name + "/";
        private const string _name = "Animator";

        public const string LogsName = EnemyAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "Logs";
    }
}