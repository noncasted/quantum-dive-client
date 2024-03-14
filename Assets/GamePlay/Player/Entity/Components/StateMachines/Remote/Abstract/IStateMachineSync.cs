using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Abstract
{
    public interface IStateMachineSync
    {
        void SetState(PlayerStateDefinition definition, IPlayerRemoteStatePayload payload = null);
    }
}