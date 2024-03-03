using GamePlay.Enemy.Entity.States.Abstract;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.States.Damaged.Common
{
    public class DamagedPayload : IRemoteStatePayload
    {
        public float Angle;
        
        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteFloat(Angle, 0, 360, 1f);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            Angle = buffer.ReadFloat(0, 360, 1f);
        }
    }
}