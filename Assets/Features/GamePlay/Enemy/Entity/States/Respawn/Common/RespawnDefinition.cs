using GamePlay.Enemies.Entity.States.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Respawn.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRespawnRoutes.DefinitionName,
        menuName = EnemyRespawnRoutes.DefinitionPath)]
    public class RespawnDefinition : EnemyStateDefinition
    {
    }
}