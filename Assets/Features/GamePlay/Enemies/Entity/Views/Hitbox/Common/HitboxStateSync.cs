using System;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Enemies.Entity.Views.Hitbox.Common
{
    public class HitboxStateSync : RagonProperty, IHitboxStateSync
    {
        protected HitboxStateSync() : base(0, false)
        {
        }

        private bool _state;
        
        public event Action<bool> StateChanged;
        
        public void SendEnable()
        {
            _state = true;
            
            MarkAsChanged();
        }

        public void SendDisable()
        {
            _state = false;
            
            MarkAsChanged();
        }

        public override void Serialize(RagonBuffer buffer)
        {
            buffer.WriteBool(_state);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var state = buffer.ReadBool();

            if (state == _state)
                return;

            _state = state;
            
            StateChanged?.Invoke(_state);
        }
    }
}