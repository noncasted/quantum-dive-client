using Global.Network.Handlers.ClientHandler.Runtime;
using Internal.Scopes.Abstract.Instances.Services;

namespace Global.Network.EventsRegistries.Runtime
{
    public class NetworkEventsRegistry : IScopeAwakeListener
    {
        public NetworkEventsRegistry(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        private readonly IClientProvider _clientProvider;

        public void OnAwake()
        {
            var eventCache = _clientProvider.Client.Event;
        }
    }
}