using GamePlay.Player.Entity.States.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RunRoutes.DefinitionName,
        menuName = RunRoutes.DefinitionPath)]
    public class RunDefinition : PlayerStateDefinition
    {
    }
}