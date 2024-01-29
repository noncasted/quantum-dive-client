using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime
{
    public interface IRemoteStateMachine
    {
        void RegisterState(PlayerStateDefinition definition, IPlayerRemoteState state);
        void UnregisterState(PlayerStateDefinition definition);

        void RegisterFlush(PlayerStateDefinition definition, IRemotePayloadFlush flush);
        void UnregisterFlush(PlayerStateDefinition definition);
    }
}