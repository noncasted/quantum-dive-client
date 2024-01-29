using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Views.Animators.Common
{
    public class AnimatorRoutes
    {
        private const string _root = PlayerAssetsPaths.Views + _name + "/";
        private const string _name = "Animator";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "Logs";
    }
}