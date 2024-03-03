using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Views.Common;

namespace GamePlay.Player.Entity.Views.Animators.Common
{
    public class AnimatorRoutes
    {
        private const string Root = PlayerViewsRoutes.Root + Name;
        private const string Name = "Animator";

        public const string LogsName = PlayerEntityPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";
    }
}