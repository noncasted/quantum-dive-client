using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Abstract
{
    public interface IPlayerRemoteState
    {
        void Enter(RagonBuffer buffer);
        void Break();
    }
}