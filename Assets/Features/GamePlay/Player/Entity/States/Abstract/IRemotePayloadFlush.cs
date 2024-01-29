using Ragon.Protocol;

namespace GamePlay.Player.Entity.States.Abstract
{
    public interface IRemotePayloadFlush
    {
        void Flush(RagonBuffer buffer);
    }
}