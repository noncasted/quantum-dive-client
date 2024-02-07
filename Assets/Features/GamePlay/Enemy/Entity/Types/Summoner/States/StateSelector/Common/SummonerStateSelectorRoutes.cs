using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.Types.Summoner.Common;

namespace GamePlay.Enemies.Entity.Types.Summoner.States.StateSelector.Common
{
    public class SummonerStateSelectorRoutes
    {
        public const string ComponentName = EnemyEntityPrefixes.Component + "StateSelector";
        public const string ComponentPath = EnemySummonerRoutes.Root + "StateSelector/Component";
    }
}