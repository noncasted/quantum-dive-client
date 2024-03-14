using Ragon.Client;

namespace GamePlay.Services.System.Network.Messaging.REST.Abstract
{
    public interface IMessageSender<TRequest, TResponse>
    {
        IRequestHandler<TRequest, TResponse> SendRequest(RagonPlayer player, TRequest payload);
        void SendResponse(RagonPlayer player, TResponse payload);
    }
}