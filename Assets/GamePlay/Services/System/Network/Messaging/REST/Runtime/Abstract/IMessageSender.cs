using Ragon.Client;

namespace GamePlay.System.Network.Messaging.REST.Runtime.Abstract
{
    public interface IMessageSender<TRequest, TResponse>
    {
        IRequestHandler<TRequest, TResponse> SendRequest(RagonPlayer player, TRequest payload);
        void SendResponse(RagonPlayer player, TResponse payload);
    }
}