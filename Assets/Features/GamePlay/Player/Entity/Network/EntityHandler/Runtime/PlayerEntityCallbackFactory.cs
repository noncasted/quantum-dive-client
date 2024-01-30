using System;
using System.Collections.Generic;

namespace GamePlay.Player.Entity.Network.EntityHandler.Runtime
{
    public class PlayerEntityCallbackFactory : IPlayerEntityCallbackFactory
    {
        private readonly List<IEntityAttachListener> _listener = new();
        
        public void Listen(object listener)
        {
            if (listener is IEntityAttachListener attachListener)
                _listener.Add(attachListener);
        }

        public void InvokeAttached()
        {
            foreach (var listener in _listener)
                listener.OnEntityAttached();
        }
    }
}