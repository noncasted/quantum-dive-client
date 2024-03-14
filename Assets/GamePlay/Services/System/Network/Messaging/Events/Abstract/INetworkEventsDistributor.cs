using Ragon.Client;

namespace GamePlay.Services.System.Network.Messaging.Events.Abstract
{
    public interface INetworkEventsDistributor
    {
        void SendAll<TEvent>(TEvent payload) where TEvent : IRagonEvent, new();
        void SendOwner<TEvent>(TEvent payload) where TEvent : IRagonEvent, new();
    }
}