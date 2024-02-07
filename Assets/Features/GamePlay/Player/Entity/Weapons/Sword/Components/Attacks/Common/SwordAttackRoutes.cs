using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Weapons.Sword.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common
{
    public class SwordAttackRoutes
    {
        private const string _root = SwordAssetsPaths.Root + _name + "/";
        private const string _name = "Attack";

        public const string LocalName = SwordAssetsPrefixes.Component + _name + "_Local";
        public const string LocalPath = _root + "Local";

        public const string RemoteName = SwordAssetsPrefixes.Component + _name + "_Remote";
        public const string RemotePath = _root + "Remote";
        
        public const string DefinitionName = PlayerEntityPrefixes.Definition + "SwordAttack";
        public const string DefinitionPath = _root + "Definition";
        
        public const string AttackAnimationName = "Animation_SwordAttack";
        public const string AttackAnimationPath = _root + "AttackAnimation";

        public const string ConfigName = SwordAssetsPrefixes.Config + _name;
        public const string ConfigPath = _root + "Config";
    }
}