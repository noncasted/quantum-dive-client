﻿//using GamePlay.Player.Entity.Definition;

namespace GamePlay.Services.System.Network.Messaging.REST.Abstract
{
    public interface IMessageDistributor
    {
        // IRequestHandler<TRequest, TResponse> SendOwner<TRequest, TResponse>(TRequest requestPayload)
        //     where TRequest : IRagonEvent, IMessage, new()
        //     where TResponse : IRagonEvent, IMessage, new();
        //
        // UniTask<TResponse> SendOwnerAsync<TRequest, TResponse>(
        //     TRequest requestPayload,
        //     CancellationToken cancellation)
        //     where TRequest : IRagonEvent, IMessage, new()
        //     where TResponse : IRagonEvent, IMessage, new();
        //
        // IReadOnlyDictionary<INetworkPlayer, IRequestHandler<TRequest, TResponse>> SendAll<TRequest, TResponse>(
        //     TRequest requestPayload)
        //     where TRequest : IRagonEvent, IMessage, new()
        //     where TResponse : IRagonEvent, IMessage, new();
        //
        // UniTask<IReadOnlyDictionary<INetworkPlayer, TResponse>> SendAllAsync<TRequest, TResponse>(
        //     TRequest requestPayload,
        //     CancellationToken cancellation)
        //     where TRequest : IRagonEvent, IMessage, new()
        //     where TResponse : IRagonEvent, IMessage, new();
    }
}