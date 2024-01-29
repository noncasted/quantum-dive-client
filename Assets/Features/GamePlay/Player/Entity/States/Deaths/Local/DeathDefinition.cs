using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Deaths.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Deaths.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DeathRoutes.DefinitionName,
        menuName = DeathRoutes.DefinitionPath)]
    public class DeathDefinition : PlayerStateDefinition
    {
    }
}