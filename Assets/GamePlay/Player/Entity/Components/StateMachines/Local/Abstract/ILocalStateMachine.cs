using Common.DataTypes.Runtime.Reactive;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Abstract
{
    public interface ILocalStateMachine
    {
        IViewableDelegate Exited { get; }

        bool IsAvailable(PlayerStateDefinition definition);
        void Enter(IPlayerLocalState playerLocalState);
        void Enter(IPlayerLocalState playerLocalState, IPlayerRemoteStatePayload payload);
        void Exit(IPlayerLocalState playerLocalState);
    }
}