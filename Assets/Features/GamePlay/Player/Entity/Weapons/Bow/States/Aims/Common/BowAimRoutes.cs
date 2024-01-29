using GamePlay.Player.Entity.Setup.Path;
using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Common
{   
    public class BowAimRoutes
    {
        private const string _root = BowAssetsPaths.Root + _name;
        private const string _name = "Aim";

        public const string LocalName = BowAssetsPrefixes.Component + _name + "_Local";
        public const string LocalPath = _root + "/Local";
        
        public const string RemoteName = BowAssetsPrefixes.Component + _name + "_Remote";
        public const string RemotePath = _root + "/Remote";
        
        public const string DefinitionName = PlayerAssetsPrefixes.Definition + "_Bow_Aim";
        public const string DefinitionPath = _root + "/Definition";
        
        public const string PlayerAnimationName = "Animation_Player_Aim";
        public const string PlayerAnimationPath = _root + "/PlayerAnimation";
        
        public const string BowAnimationName = "Animation_Bow_Aim";
        public const string BowAnimationPath = _root + "/BowAnimation";
    }
}