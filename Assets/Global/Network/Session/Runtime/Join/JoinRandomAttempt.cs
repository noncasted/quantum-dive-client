using Cysharp.Threading.Tasks;
using Global.Network.Session.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace Global.Network.Session.Runtime.Join
{
        public class JoinRandomAttempt : IRagonFailedListener, IRagonSceneRequestListener
        {
            public JoinRandomAttempt(RagonClient client)
            {
                _client = client;
            }
        
            private readonly RagonClient _client;

            private readonly UniTaskCompletionSource<SessionJoinResult> _completion = new();

            public async UniTask<SessionJoinResult> JoinRandom()
            {   
                Listen();

                var parameters = new RagonRoomParameters
                {
                    Min = 0,
                    Max = 20,
                    Scene = "Level"
                };
                
                _client.Session.CreateOrJoin(parameters);
                var result = await _completion.Task;

                await UniTask.Yield();

                Unlisten();
                
                return result;
            }
        
            public void OnFailed(RagonClient client, string message)
            {
                _completion.TrySetResult(new SessionJoinResult(SessionJoinResultType.Fail, message));
            }
        
            private void Listen()
            {
                _client.AddListener((IRagonSceneRequestListener)this);
                _client.AddListener((IRagonFailedListener)this);
            }

            private void Unlisten()
            {
                _client.RemoveListener((IRagonSceneRequestListener)this);
                _client.RemoveListener((IRagonFailedListener)this);
            }

            public void OnRequestScene(RagonClient client, string sceneName)
            {
                _completion.TrySetResult(new SessionJoinResult(SessionJoinResultType.Success));
            }
        }
}