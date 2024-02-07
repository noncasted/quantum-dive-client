using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.States.Abstract
{
    public interface IRemoteStatePayloadFlush
    {
        void FlushPayload(RagonBuffer buffer);
    }
}