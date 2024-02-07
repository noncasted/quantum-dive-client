using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.States.Common;

namespace GamePlay.Enemy.Entity.States.SubStates.Pushes.Common
{
    public class EnemySubPushRoutes
    {
        public const string StateName = EnemyEntityPrefixes.State + "Push";
        public const string StatePath = EnemyStatesRoutes.Root + "Push";
    }
}