using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Deaths.Common
{
    public class DeathRoutes
    {
        private const string Root = PlayerStatesRoutes.Root + Name;
        private const string Name = "Death";

        public const string StateName = PlayerAssetsPrefixes.Component + Name;
        public const string StatePath = Root + "/State";

        public const string DefinitionName = PlayerAssetsPrefixes.Definition + Name;
        public const string DefinitionPath = Root + "/Definition";
        
        public const string AnimationTriggerName = "AnimationTrigger_Death";
        public const string AnimationTriggerPath = Root + "/AnimationTrigger";
    }
}