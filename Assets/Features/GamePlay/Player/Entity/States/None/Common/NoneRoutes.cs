using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.None.Common
{
    public class NoneRoutes
    {
        private const string _root = PlayerAssetsPaths.States + _name;
        private const string _name = "None";

        public const string StateName = PlayerAssetsPrefixes.Component + _name;
        public const string StatePath = _root + "/State";

        public const string LogsName = PlayerAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";
        
        public const string DefinitionName = PlayerAssetsPrefixes.Definition + _name;
        public const string DefinitionPath = _root + "/Definition";
    }
}