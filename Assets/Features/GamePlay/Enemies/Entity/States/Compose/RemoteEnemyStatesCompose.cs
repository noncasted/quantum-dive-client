using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Enemies.Entity.States.Common;
using GamePlay.Enemies.Entity.States.Damaged.Remote;
using GamePlay.Enemies.Entity.States.Death.Remote;
using GamePlay.Enemies.Entity.States.Following.Remote;
using GamePlay.Enemies.Entity.States.Idle.Remote;
using GamePlay.Enemies.Entity.States.Respawn.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Enemies.Entity.States.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "RemoteEnemyStatesCompose",
        menuName = EnemyStatesRoutes.Root + "Compose/Remote")]
    public class RemoteEnemyStatesCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private RemoteDamagedFactory _damaged;
        [SerializeField] private RemoteDeathFactory _death;
        [SerializeField] private RemoteFollowingFactory _following;
        [SerializeField] private RemoteIdleFactory _idle;
        [SerializeField] private RemoteRespawnFactory _respawn;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _damaged,
            _death,
            _following,
            _idle,
            _respawn
        };
    }
}