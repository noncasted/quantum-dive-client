using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.None.Common
{
    public class NoneRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name;
        private const string Name = "None";

        public const string StateName = PlayerEntityPrefixes.Component + Name;
        public const string StatePath = Root + "/State";

        public const string LogsName = PlayerEntityPrefixes.Logs + Name;
        public const string LogsPath = Root + "/Logs";
        
        public const string DefinitionName = PlayerEntityPrefixes.Definition + Name;
        public const string DefinitionPath = Root + "/Definition";
    }
}