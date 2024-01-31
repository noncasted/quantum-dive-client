using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Floating.Common
{
    public class FloatingRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name;
        private const string Name = "Floating";

        public const string StateName = PlayerAssetsPrefixes.Component + Name;
        public const string StatePath = Root + "/State";

        public const string LogsName = PlayerAssetsPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";
    }
}