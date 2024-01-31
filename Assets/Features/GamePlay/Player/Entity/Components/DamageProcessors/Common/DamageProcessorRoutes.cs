using Features.GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Common
{
    public static class DamageProcessorRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + Name;
        private const string Name = "DamageProcessor";

        public const string ComponentName = PlayerAssetsPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";
        
        public const string ConfigName = PlayerAssetsPrefixes.Config + Name;
        public const string ConfigPath = Root + "/Config";
    }
}