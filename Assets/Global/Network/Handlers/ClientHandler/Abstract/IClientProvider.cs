using Ragon.Client;

namespace Global.Network.Handlers.ClientHandler.Abstract
{
    public interface IClientProvider
    {
        RagonClient Client { get; }
    }
}