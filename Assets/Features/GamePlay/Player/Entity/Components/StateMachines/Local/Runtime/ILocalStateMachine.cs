using System;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Runtime
{
    public interface ILocalStateMachine
    {
        event Action Exited;

        bool IsAvailable(PlayerStateDefinition definition);
        void Enter(IPlayerLocalState playerLocalState);
        void Enter(IPlayerLocalState playerLocalState, IPlayerRemoteStatePayload payload);
        void Exit(IPlayerLocalState playerLocalState);
    }
}