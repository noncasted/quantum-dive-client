using GamePlay.Player.Entity.States.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Respawns.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RespawnRoutes.DefinitionName,
        menuName = RespawnRoutes.DefinitionPath)]
    public class RespawnDefinition : PlayerStateDefinition
    {
    }
}