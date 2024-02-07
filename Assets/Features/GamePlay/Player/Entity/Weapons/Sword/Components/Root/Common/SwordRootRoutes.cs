using GamePlay.Player.Entity.Weapons.Sword.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Root.Common
{
    public class SwordRootRoutes
    {
        private const string Paths = SwordAssetsPaths.Root;
        
        public const string LocalPath = Paths + "Local";
        public const string LocalName = SwordAssetsPrefixes.Component + "Root_Local";

        public const string DefinitionName = "SlotDefinition_Sword";
        public const string DefinitionPath = Paths + "Definition";
    }
}