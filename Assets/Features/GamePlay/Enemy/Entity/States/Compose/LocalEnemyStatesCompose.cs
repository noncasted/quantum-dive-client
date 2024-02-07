using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.States.Common;
using GamePlay.Enemies.Entity.States.Damaged.Local;
using GamePlay.Enemies.Entity.States.Death.Local;
using GamePlay.Enemies.Entity.States.Following.Local;
using GamePlay.Enemies.Entity.States.Idle.Local;
using GamePlay.Enemies.Entity.States.Respawn.Local;
using GamePlay.Enemies.Entity.States.SubStates.Pushes.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "LocalEnemyStatesCompose",
        menuName = EnemyStatesRoutes.Root + "Compose/Local")]
    public class LocalEnemyStatesCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private LocalDamagedFactory _damaged;
        [SerializeField] private LocalDeathFactory _death;
        [SerializeField] private LocalFollowingFactory _following;
        [SerializeField] private LocalIdleFactory _idle;
        [SerializeField] private LocalRespawnFactory _respawn;
        [SerializeField] private SubPushFactory _subPush;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _damaged,
            _death,
            _following,
            _idle,
            _respawn,
            _subPush
        };
    }
}