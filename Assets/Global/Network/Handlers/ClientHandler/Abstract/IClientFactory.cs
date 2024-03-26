using Ragon.Client;

namespace Global.Network.Handlers.ClientHandler.Abstract
{
    public interface IClientFactory
    {
        RagonClient Create();
    }
}