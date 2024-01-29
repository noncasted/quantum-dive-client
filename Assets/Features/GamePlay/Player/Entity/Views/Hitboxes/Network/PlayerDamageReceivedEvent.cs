using Common.DataTypes.Network;
using GamePlay.Common.Damages;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Views.Hitboxes.Network
{
    public class PlayerDamageReceivedEvent : IRagonEvent
    {
        public Damage Damage;

        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteInt(Damage.Amount, 0, 1024);
            buffer.WriteFloat(Damage.PushForce, 0f, 128f, 0.01f);
            buffer.WritePosition(Damage.Direction);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            var amount = buffer.ReadInt(0, 1024);
            var pushForce = buffer.ReadFloat(0f, 128f, 0.01f);
            var origin = buffer.ReadPosition();

            Damage = new Damage(amount, pushForce, origin);
        }
    }
}