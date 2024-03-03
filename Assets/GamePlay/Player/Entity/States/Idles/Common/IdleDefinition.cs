using GamePlay.Player.Entity.States.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Idles.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = IdleRoutes.DefinitionName,
        menuName = IdleRoutes.DefinitionPath)]
    public class IdleDefinition : PlayerStateDefinition
    {
    }
}