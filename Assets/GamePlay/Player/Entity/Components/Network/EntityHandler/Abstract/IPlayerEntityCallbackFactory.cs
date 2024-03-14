
using Internal.Scopes.Abstract.Callbacks;

namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime
{
    public interface IPlayerEntityCallbackFactory : ICallbacksListener
    {
        void InvokeAttached();
    }
}