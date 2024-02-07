using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.Types.Melee.Common;

namespace GamePlay.Enemies.Entity.Types.Melee.States.StateSelector.Common
{
    public class MeleeStateSelectorRoutes
    {
        public const string ComponentName = EnemyAssetsPrefixes.Component + "StateSelector";
        public const string ComponentPath = EnemyMeleeRoutes.Root + "StateSelector/Component";
    }
}