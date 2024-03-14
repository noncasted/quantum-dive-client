using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Abstract
{
    public interface IRemoteStateMachine
    {
        void RegisterState(ILifetime lifetime, PlayerStateDefinition definition, IPlayerRemoteState state);

        void RegisterFlush(PlayerStateDefinition definition, IRemotePayloadFlush flush);
        void UnregisterFlush(PlayerStateDefinition definition);
    }
}