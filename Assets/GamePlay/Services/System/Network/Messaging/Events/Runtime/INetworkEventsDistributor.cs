using Ragon.Client;

namespace GamePlay.System.Network.Messaging.Events.Runtime
{
    public interface INetworkEventsDistributor
    {
        void SendAll<TEvent>(TEvent payload) where TEvent : IRagonEvent, new();
        void SendOwner<TEvent>(TEvent payload) where TEvent : IRagonEvent, new();
    }
}