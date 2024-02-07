using Features.GamePlay.Enemies.Entity.States.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.States.SubStates.Pushes.Common
{
    public class EnemySubPushRoutes
    {
        public const string StateName = EnemyAssetsPrefixes.State + "Push";
        public const string StatePath = EnemyStatesRoutes.Root + "Push";
    }
}