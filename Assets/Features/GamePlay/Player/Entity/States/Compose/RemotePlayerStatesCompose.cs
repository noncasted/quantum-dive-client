using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Idles.Remote;
using GamePlay.Player.Entity.States.Respawns.Remote;
using GamePlay.Player.Entity.States.Roll.Remote;
using GamePlay.Player.Entity.States.Runs.Remote;
using GamePlay.Player.Entity.States.SubStates.Damaged.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "RemotePlayer_StatesCompose",
        menuName = PlayerStatesRoutes.Root + "Compose/Remote")]
    public class RemotePlayerStatesCompose : ScriptableObject, IComponentsCompose
    {
       // [SerializeField] private RemoteDeathFactory _death;
        [SerializeField] private RemoteIdleFactory _idle;
        [SerializeField] private RemoteRespawnFactory _respawn;
        [SerializeField] private RemoteRollFactory _roll;
        [SerializeField] private RemoteRunFactory _run;
        [SerializeField] private RemoteDamagedFactory _damaged;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
       //     _death,
            _idle,
            _respawn,
            _roll,
            _run,
            _damaged,
        };
    }
}