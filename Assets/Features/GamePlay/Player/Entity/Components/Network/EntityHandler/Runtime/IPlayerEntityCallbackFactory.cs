using Common.Architecture.Container.Abstract;

namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime
{
    public interface IPlayerEntityCallbackFactory : ICallbackRegistry
    {
        void InvokeAttached();
    }
}