using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.Views.Common;

namespace GamePlay.Player.Entity.Views.Transforms.Local.Common
{
    public class TransformRoutes
    {
        private const string Root = PlayerViewsRoutes.Root + Name;
        private const string Name = "Transform";

        public const string LogsName = PlayerEntityPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";
    }
}