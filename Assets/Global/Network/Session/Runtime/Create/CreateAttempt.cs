using Cysharp.Threading.Tasks;
using Global.Network.Session.Abstract;
using Ragon.Client;

namespace Global.Network.Session.Runtime.Create
{
    public class CreateAttempt : IRagonFailedListener, IRagonSceneRequestListener
    {
        public CreateAttempt(RagonClient client)
        {
            _client = client;
        }
        
        private readonly RagonClient _client;

        private readonly UniTaskCompletionSource<SessionCreateResult> _completion = new();

        public async UniTask<SessionCreateResult> Create(string id)
        {
            Listen();
            
            _client.Session.Create(id, "", 1, 16);
            
            var result = await _completion.Task;

            await UniTask.Yield();

            Unlisten();

            return result;
        }
        
        public void OnFailed(RagonClient client, string message)
        {
            _completion.TrySetResult(new SessionCreateResult(SessionCreateResultType.Success, message));
        }
        
        private void Listen()
        {
            _client.AddListener((IRagonFailedListener)this);
            _client.AddListener((IRagonSceneRequestListener)this);
        }

        private void Unlisten()
        {
            _client.RemoveListener((IRagonFailedListener)this);
            _client.RemoveListener((IRagonSceneRequestListener)this);
        }

        public void OnRequestScene(RagonClient client, string sceneName)
        {
            _completion.TrySetResult(new SessionCreateResult(SessionCreateResultType.Success));
        }
    }
}