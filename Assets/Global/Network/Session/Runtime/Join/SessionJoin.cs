using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Abstract;
using Global.Network.Session.Abstract;

namespace Global.Network.Session.Runtime.Join
{
    public class SessionJoin : ISessionJoin
    {
        public SessionJoin(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }
        
        private readonly IClientProvider _clientProvider;

        public async UniTask<SessionJoinResult> Join(string id)
        {
            var attempt = new JoinAttempt(_clientProvider.Client);

            return await attempt.Join(id);
        }

        public async UniTask<SessionJoinResult> JoinRandom()
        {
            var attempt = new JoinRandomAttempt(_clientProvider.Client);

            return await attempt.JoinRandom();
        }
    }
}