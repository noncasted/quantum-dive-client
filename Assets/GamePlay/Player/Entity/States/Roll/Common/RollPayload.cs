using GamePlay.Player.Entity.States.Abstract;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Common
{
    public class RollPayload : IPlayerRemoteStatePayload
    {
        public Vector2 Direction;

        public void Serialize(RagonBuffer buffer)
        {
        }

        public void Deserialize(RagonBuffer buffer)
        {
        }
    }
}