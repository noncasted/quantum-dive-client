using Cysharp.Threading.Tasks;
using Global.Network.Connection.Abstract;
using Global.Network.Connection.Configuration;
using Ragon.Client;
using Ragon.Protocol;

namespace Global.Network.Connection.Runtime
{
    public struct ConnectionAttempt : IRagonConnectionListener, IRagonFailedListener, IRagonAuthorizationListener
    {
        public ConnectionAttempt(RagonClient client, IRagonConnectionOptions options)
        {
            _client = client;
            _options = options;

            _connectCompletion = new UniTaskCompletionSource<ConnectionResultType>();
            _authorizeCompletion = new UniTaskCompletionSource<ConnectionResultType>();
        }

        private readonly RagonClient _client;
        private readonly IRagonConnectionOptions _options;
        
        private readonly UniTaskCompletionSource<ConnectionResultType> _connectCompletion;
        private readonly UniTaskCompletionSource<ConnectionResultType> _authorizeCompletion;

        public async UniTask<ConnectionResultType> Connect(string playerName)
        {
            Listen();
        
            _client.Connect(_options.Address, _options.Port, _options.Protocol);

            var connectionResult = await _connectCompletion.Task;

            await UniTask.Yield();
            
            if (connectionResult == ConnectionResultType.Fail)
            {
                Unlisten();

                return ConnectionResultType.Fail;
            }

            _client.Session.AuthorizeWithKey("defaultkey", playerName);

            var authorizeResult = await _authorizeCompletion.Task;
            await UniTask.Yield();

            Unlisten();
            
            if (authorizeResult == ConnectionResultType.Fail)
                return ConnectionResultType.Fail;
            
            return ConnectionResultType.Success;
        }

        public void OnConnected(RagonClient client)
        {
            _connectCompletion.TrySetResult(ConnectionResultType.Success);
        }

        public void OnDisconnected(RagonClient client, RagonDisconnect reason)
        {
            
        }

        public void OnDisconnected(RagonClient client)
        {
            _connectCompletion.TrySetResult(ConnectionResultType.Fail);
        }

        public void OnFailed(RagonClient client, string message)
        {
            _connectCompletion.TrySetResult(ConnectionResultType.Fail);
        }

        public void OnAuthorizationSuccess(RagonClient client, string playerId, string playerName)
        {
            _authorizeCompletion.TrySetResult(ConnectionResultType.Success);
        }

        public void OnAuthorizationFailed(RagonClient client, string message)
        {
            _authorizeCompletion.TrySetResult(ConnectionResultType.Fail);
        }

        private void Listen()
        {
            _client.AddListener((IRagonConnectionListener)this);
            _client.AddListener((IRagonFailedListener)this);
            _client.AddListener((IRagonAuthorizationListener)this);
        }

        private void Unlisten()
        {
            _client.RemoveListener((IRagonConnectionListener)this);
            _client.RemoveListener((IRagonFailedListener)this);
            _client.RemoveListener((IRagonAuthorizationListener)this);
        }
    }
}