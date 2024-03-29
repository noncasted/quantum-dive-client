﻿using Common.DataTypes.Runtime.Reactive;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Views.Hitboxes.Network
{
    public class HitboxSync : RagonProperty, IHitboxSync
    {
        protected HitboxSync() : base(0, false)
        {
        }

        private bool _state;
        private readonly ViewableDelegate<bool> _stateChanged = new();


        public IViewableDelegate<bool> StateChanged => _stateChanged;

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
            _state = buffer.ReadBool();

            _stateChanged?.Invoke(_state);
        }
    }
}