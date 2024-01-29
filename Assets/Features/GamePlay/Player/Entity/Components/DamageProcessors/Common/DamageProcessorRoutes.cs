using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Common
{
    public static class DamageProcessorRoutes
    {
        private const string _root = PlayerAssetsPaths.System + _name;
        private const string _name = "DamageProcessor";

        public const string ComponentName = PlayerAssetsPrefixes.Component + _name;
        public const string ComponentPath = _root + "/Component";
        
        public const string ConfigName = PlayerAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "/Config";
    }
}