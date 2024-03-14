using Internal.Scopes.Abstract.Callbacks;

namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract
{
    public interface IPlayerEntityCallbackFactory : ICallbacksListener
    {
        void InvokeAttached();
    }
}