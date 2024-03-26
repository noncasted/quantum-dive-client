using Cysharp.Threading.Tasks;
using Global.Network.Session.Abstract;
using Ragon.Client;

namespace Global.Network.Session.Runtime.Leave
{
    public class LeaveAttempt : IRagonLeftListener, IRagonFailedListener
    {
        public LeaveAttempt(RagonClient client)
        {
            _client = client;
        }
        
        private readonly RagonClient _client;

        private readonly UniTaskCompletionSource<SessionLeaveResult> _completion = new();

        public async UniTask<SessionLeaveResult> Join(string id)
        {
            Listen();

            var result = await _completion.Task;

            return result;
        }
        
        public void OnLeft(RagonClient client)
        {
            _completion.TrySetResult(SessionLeaveResult.Success);
        }

        public void OnFailed(RagonClient client, string message)
        {
            _completion.TrySetResult(SessionLeaveResult.Fail);
        }
        
        private void Listen()
        {
            _client.AddListener((IRagonLeftListener)this);
            _client.AddListener((IRagonFailedListener)this);
        }

        private void Unlisten()
        {
            _client.RemoveListener((IRagonLeftListener)this);
            _client.RemoveListener((IRagonFailedListener)this);
        }
    }
}