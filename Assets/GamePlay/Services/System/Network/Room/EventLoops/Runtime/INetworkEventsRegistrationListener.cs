using Ragon.Client;

namespace GamePlay.System.Network.Room.EventLoops.Runtime
{
    public interface INetworkEventsRegistrationListener
    {
        void RegisterEvents(RagonEventCache events);
    }
}