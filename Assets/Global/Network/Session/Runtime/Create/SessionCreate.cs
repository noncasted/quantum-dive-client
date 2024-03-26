using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Abstract;
using Global.Network.Session.Abstract;

namespace Global.Network.Session.Runtime.Create
{
    public class SessionCreate : ISessionCreate
    {
        public SessionCreate(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }
        
        private readonly IClientProvider _clientProvider;

        public async UniTask<SessionCreateResult> Create(string roomId)
        {
            var attempt = new CreateAttempt(_clientProvider.Client);

            return await attempt.Create(roomId);
        }
    }
}