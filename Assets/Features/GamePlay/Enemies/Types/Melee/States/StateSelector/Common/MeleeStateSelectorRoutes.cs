using Features.GamePlay.Enemies.Types.Melee.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Types.Melee.States.StateSelector.Common
{
    public class MeleeStateSelectorRoutes
    {
        public const string ComponentName = EnemyAssetsPrefixes.Component + "StateSelector";
        public const string ComponentPath = EnemyMeleeRoutes.Root + "StateSelector/Component";
    }
}