using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Common;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Common
{
    public static class DamageProcessorRoutes
    {
        private const string Root = PlayerComponentsRoutes.Root + Name;
        private const string Name = "DamageProcessor";

        public const string ComponentName = PlayerEntityPrefixes.Component + Name;
        public const string ComponentPath = Root + "/Component";
        
        public const string ConfigName = PlayerEntityPrefixes.Config + Name;
        public const string ConfigPath = Root + "/Config";
    }
}