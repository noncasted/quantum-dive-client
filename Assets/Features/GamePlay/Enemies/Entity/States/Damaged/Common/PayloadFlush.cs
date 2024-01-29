using GamePlay.Enemies.Entity.States.Abstract;
using Ragon.Protocol;

namespace GamePlay.Enemies.Entity.States.Damaged.Common
{
    public class PayloadFlush : IRemoteStatePayloadFlush
    {
        public void FlushPayload(RagonBuffer buffer)
        {
            buffer.ReadFloat(0, 360, 1f);
        }
    }
}