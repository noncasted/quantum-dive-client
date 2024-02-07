using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.States.Common;

namespace GamePlay.Enemies.Entity.States.SubStates.Pushes.Common
{
    public class EnemySubPushRoutes
    {
        public const string StateName = EnemyEntityPrefixes.State + "Push";
        public const string StatePath = EnemyStatesRoutes.Root + "Push";
    }
}