using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Deaths.Local;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.States.Idles.Local;
using GamePlay.Player.Entity.States.None.Runtime;
using GamePlay.Player.Entity.States.Respawns.Local;
using GamePlay.Player.Entity.States.Roll.Local;
using GamePlay.Player.Entity.States.Runs.Local;
using GamePlay.Player.Entity.States.Runs.Remote;
using GamePlay.Player.Entity.States.SubStates.Damaged.Local;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "LocalPlayer_StatesCompose",
        menuName = PlayerStatesRoutes.Root + "Compose/Local")]
    public class LocalPlayerStatesCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private LocalDeathFactory _death;
        [SerializeField] private FloatingStateFactory _floating;
        [SerializeField] private LocalIdleFactory _idle;
        [SerializeField] private NoneFactory _none;
        [SerializeField] private LocalRespawnFactory _respawn;
        [SerializeField] private LocalRollFactory _roll;
        [SerializeField] private LocalRunFactory _run;
        [SerializeField] private LocalDamagedFactory _damaged;
        [SerializeField] private SubPushFactory _push;
        [SerializeField] private RemoteRunFactory _remoteRun;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _death,
            _floating,
            _idle,
            _none,
            _respawn,
            _roll,
            _run,
            _damaged,
            _push
        };
    }
}