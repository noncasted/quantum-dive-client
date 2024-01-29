using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.States.Deaths.Common
{
    public class DeathRoutes
    {
        private const string _root = PlayerAssetsPaths.States + _name;
        private const string _name = "Death";

        public const string StateName = PlayerAssetsPrefixes.Component + _name;
        public const string StatePath = _root + "/State";

        public const string DefinitionName = PlayerAssetsPrefixes.Definition + _name;
        public const string DefinitionPath = _root + "/Definition";
        
        public const string AnimationTriggerName = "AnimationTrigger_Death";
        public const string AnimationTriggerPath = _root + "/AnimationTrigger";
    }
}