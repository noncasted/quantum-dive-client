using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Common
{
    public class ShootRoutes
    {
        private const string _root = BowAssetsPaths.Root + _name;
        private const string _name = "Shooter";

        public const string FreeComponentName = BowAssetsPrefixes.Component + _name + "_Free2";
        public const string FreeComponentPath = _root + "/FreeState";
        
        public const string LocalName = BowAssetsPrefixes.Component + _name + "_Local";
        public const string LocalPath = _root + "/Local";
        
        public const string RemoteName = BowAssetsPrefixes.Component + _name + "_Remote";
        public const string RemotePath = _root + "/Remote";
        
        public const string DefinitionName = PlayerAssetsPrefixes.Definition + _name;
        public const string DefinitionPath = _root + "/Definition";
        
        public const string BowAnimationName = "Bow_Shoot_Animaton";
        public const string BowAnimationPath = _root + "/BowAnimation";
        
        public const string PlayerAnimationName = "Player_Shoot_Animaton";
        public const string PlayerAnimationPath = _root + "/PlayerAnimation";
    }
}