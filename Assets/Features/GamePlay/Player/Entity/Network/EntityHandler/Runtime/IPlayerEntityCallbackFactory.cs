﻿using Common.Architecture.Container.Abstract;

namespace GamePlay.Player.Entity.Network.EntityHandler.Runtime
{
    public interface IPlayerEntityCallbackFactory : ICallbackRegister
    {
        void InvokeAttached();
    }
}