using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Common
{
    public class DataRoutes
    {
        private const string _root = BowAssetsPaths.Root + _name + "/";
        private const string _name = "Data";

        public const string ProjectilesAmountName = BowAssetsPrefixes.Data + "ProjectilesAmount";
        public const string ProjectilesAmountPath = _root + "ProjectilesAmount";
        
        public const string ShotDelayName = BowAssetsPrefixes.Data + "ShotDelay";
        public const string ShotDelayPath = _root + "ShotDelay";
        
        public const string SpreadingName = BowAssetsPrefixes.Data + "Spreading";
        public const string SpreadingPath = _root + "Spreading";
    }
}