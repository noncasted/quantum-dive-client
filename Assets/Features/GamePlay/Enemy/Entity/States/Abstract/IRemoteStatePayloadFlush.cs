using Ragon.Protocol;

namespace GamePlay.Enemies.Entity.States.Abstract
{
    public interface IRemoteStatePayloadFlush
    {
        void FlushPayload(RagonBuffer buffer);
    }
}