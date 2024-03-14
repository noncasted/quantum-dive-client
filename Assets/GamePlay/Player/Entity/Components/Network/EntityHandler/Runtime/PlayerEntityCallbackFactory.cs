using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract;

namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime
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