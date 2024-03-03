using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Types.Melee.Common;

namespace GamePlay.Enemy.Entity.Types.Melee.States.StateSelector.Common
{
    public class MeleeStateSelectorRoutes
    {
        public const string ComponentName = EnemyEntityPrefixes.Component + "StateSelector";
        public const string ComponentPath = EnemyMeleeRoutes.Root + "StateSelector/Component";
    }
}