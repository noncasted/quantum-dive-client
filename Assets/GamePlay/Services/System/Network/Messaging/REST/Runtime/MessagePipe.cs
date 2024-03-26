using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Services.System.Network.Messaging.REST.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Network.Messaging.REST.Runtime
{
    public class MessagePipe<TRequest, TResponse> : IMessagePipe<TRequest, TResponse>,
        IMessageSender<TRequest, TResponse>
        where TRequest : IRagonEvent, IMessage, new()
        where TResponse : IRagonEvent, IMessage, new()
    {
        public MessagePipe(RagonEntity entity)
        {
            _entity = entity;

            _requestListener = _entity.OnEvent<TRequest>(OnRequest);
            _responseListener = _entity.OnEvent<TResponse>(OnResponse);
        }

        private readonly RagonEntity _entity;

        private readonly IDisposable _requestListener;
        private readonly IDisposable _responseListener;

        private readonly Dictionary<Guid, IRequestHandler<TRequest, TResponse>> _requestHandlers = new();

        private Func<IResponseHandler<TRequest, TResponse>, UniTask> _requestRoute;

        public void Dispose()
        {
            _requestListener.Dispose();
            _responseListener.Dispose();
        }

        public void AddRequestRoute(Func<IResponseHandler<TRequest, TResponse>, UniTask> route)
        {
            _requestRoute = route;
        }

        public IRequestHandler<TRequest, TResponse> SendRequest(RagonPlayer player, TRequest payload)
        {
            var id = Guid.NewGuid();
            payload.RequestId.SetValue(id);

            var requestHandler = new RequestHandler<TRequest, TResponse>(id, player, payload);
            _requestHandlers.Add(id, requestHandler);
            _entity.ReplicateEvent(payload, player, RagonReplicationMode.Server);

            return requestHandler;
        }

        public void SendResponse(RagonPlayer player, TResponse payload)
        {
            _entity.ReplicateEvent(payload, player, RagonReplicationMode.Server);
        }

        private void OnRequest(RagonPlayer player, TRequest request)
        {
            var responseHandler = new ResponseHandler<TRequest, TResponse>(player, request, this);
            _requestRoute?.Invoke(responseHandler).Forget();
        }

        private void OnResponse(RagonPlayer player, TResponse response)
        {
            if (_requestHandlers.TryGetValue(response.RequestId.Value, out var responseHandler) == false)
            {
                throw new NullReferenceException();
            }

            responseHandler.OnResponded(response);
        }
    }
}