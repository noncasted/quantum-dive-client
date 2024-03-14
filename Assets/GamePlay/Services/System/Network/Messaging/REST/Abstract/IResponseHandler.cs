namespace GamePlay.Services.System.Network.Messaging.REST.Abstract
{
    public interface IResponseHandler<TRequest, TResponse>
    {
        TRequest RequestPayload { get; }

        void Response(TResponse payload);
    }
}