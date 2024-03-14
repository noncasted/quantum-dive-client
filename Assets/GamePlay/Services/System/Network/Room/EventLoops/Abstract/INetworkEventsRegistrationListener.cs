using Ragon.Client;

namespace GamePlay.Services.System.Network.Room.EventLoops.Abstract
{
    public interface INetworkEventsRegistrationListener
    {
        void RegisterEvents(RagonEventCache events);
    }
}