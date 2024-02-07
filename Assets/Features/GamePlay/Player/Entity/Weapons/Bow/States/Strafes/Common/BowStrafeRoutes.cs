using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common
{
    public class BowStrafeRoutes
    {
        private const string _root = BowAssetsPaths.Root + _name + "/";
        private const string _name = "Strafe";

        public const string LocalName = BowAssetsPrefixes.Component + _name + "_Local";
        public const string LocalPath = _root + "Local";
        
        public const string RemoteName = BowAssetsPrefixes.Component + _name + "_Remote";
        public const string RemotePath = _root + "Remote";
        
        public const string InputName = BowAssetsPrefixes.Component + _name + "_Input";
        public const string InputPath = _root + "Input";
        
        public const string DefinitionName = PlayerEntityPrefixes.Definition + "_Bow_Strafe";
        public const string DefinitionPath = _root + "Definition";
        
        public const string PlayerAnimationName = "Animation_Player_Strafe";
        public const string PlayerAnimationPath = _root + "PlayerAnimation";
        
        public const string BowAnimationName = "Animation_Bow_Strafe";
        public const string BowAnimationPath = _root + "BowAnimation";
    }
}