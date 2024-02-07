using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Root.Common
{
    public class BowRootRoutes
    {
        private const string Paths = BowAssetsPaths.Root;
        
        public const string LocalPath = Paths + "Local";
        public const string LocalName = BowAssetsPrefixes.Component + "Root_Local";

        public const string DefinitionName = "SlotDefinition_Bow";
        public const string DefinitionPath = Paths + "Definition";
    }
}