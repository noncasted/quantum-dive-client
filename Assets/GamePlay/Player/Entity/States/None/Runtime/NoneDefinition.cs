using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.None.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.None.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NoneRoutes.DefinitionName,
        menuName = NoneRoutes.DefinitionPath)]
    public class NoneDefinition : PlayerStateDefinition
    {
    }
}